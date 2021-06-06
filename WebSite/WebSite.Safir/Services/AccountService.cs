using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Safir.Helper;
using Microsoft.JSInterop;
using WebSite.Safir.Models;

namespace WebSite.Safir.Services
{
    public interface IAccountService
    {
        Models.LoginUserModel User { get; }
        Task Initialize();
        Task<FluentResult> Login(long userName, string password, int appllicationId);
        Task<FluentResult> LogOut();
    }

    public class AccountService: IAccountService
    {

        #region Inject

        private ServiceCaller _serviceCaller;

        private Settings _settings;

        private UserLoginData _userLoginData;

        private IJSRuntime _jsRuntime;

        #endregion

        public LoginUserModel User { get; private set; }
        private string _tokenName = "UserToken";

        public AccountService(IJSRuntime jsRuntime, UserLoginData userLoginData, Settings settings, ServiceCaller serviceCaller)
        {
            _jsRuntime = jsRuntime;
            _userLoginData = userLoginData;
            _settings = settings;
            _serviceCaller = serviceCaller;
        }

        public async Task Initialize()
        {
            var resp = await _jsRuntime.GetItems<LoginUserModel>("Token");
            if (resp != null && resp.UserId > 0)
            {
                User = resp;
            }
            else
            {
                User = new LoginUserModel();
            }

            _userLoginData.UserData = User;
        }

        public async Task<FluentResult> Login(long userName, string password, int appllicationId)
        {
            FluentResult<Models.LoginModel> result =
                new FluentResult<Models.LoginModel>();

            try
            {
                if (userName < 1 || appllicationId < 1 || string.IsNullOrEmpty(password))
                {
                    result.WithError("اطلاعات ورودی صحیح نمی باشد");
                    return result;
                }

                var command = new
                {
                    UserName = userName,
                    ApplicationId = appllicationId,
                    Password = password
                };

                result = _serviceCaller.PostDataWithValue<Models.LoginModel>("loginUser/LoginUser", command).Result;

                if (result == null || result.IsFailed || result.Value == null || string.IsNullOrEmpty(result.Value.Token))
                {
                    return result;
                }

                if (result.IsSuccess)
                {
                    SetHttpContext(result.Value);
                    await _jsRuntime.SetItems<LoginUserModel>(_tokenName, User);
                }
            }
            catch(Exception ex)
            {
                result = new FluentResult<Models.LoginModel>();
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult> LogOut()
        {
            FluentResult<Models.LoginModel> result =
               new FluentResult<Models.LoginModel>();
            try
            {
                _userLoginData.UserData = new Models.LoginUserModel();

                await _jsRuntime.RemoveItems(_tokenName);

                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
                result.IsFailed = true;
            }

            return result;
        }


        #region PrivateMethods

        private void SetHttpContext(Models.LoginModel model)
        {
            if (model == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(model.Token))
            {
                return;
            }

            var validate = ValidateToken(model.Token);

            if (validate == null)
            {
                return;
            }

            var appId = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "ApplicationId".ToLower()).Value;
            var userId = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "UserId".ToLower()).Value;
            var store = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "StoreId".ToLower()).Value;
            var name = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "Name".ToLower()).Value;
            var phoneNumber = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "PhoneNumber".ToLower()).Value;

            Models.LoginUserModel user = new Models.LoginUserModel()
            {
                UserId = Convert.ToInt32(userId),
                StoreId = store,
                Name = name,
                ApplicationId = Convert.ToInt32(appId),
                PhoneNumber = phoneNumber,
                Token = model.Token,
                UserIp = ""
            };

            _userLoginData.UserData = user;
            User = user;
        }

        private JwtSecurityToken ValidateToken(string token)
        {

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateIssuer = true,
                ValidIssuer = _settings.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = _settings.Issuer,
                ClockSkew = TimeSpan.FromMinutes(2)
            };

            try
            {
                var principal = new JwtSecurityTokenHandler()
                    .ValidateToken(token, validationParameters, out var rawValidatedToken);

                return (JwtSecurityToken)rawValidatedToken;
            }
            catch (SecurityTokenValidationException ex)
            {
                return null;
            }
        }

        #endregion
    }
}
