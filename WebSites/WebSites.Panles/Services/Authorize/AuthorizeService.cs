using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IAuthorizeService
    {
        FluentResult Login(long userName, string password, int appllicationId);
        FluentResult CheckAccess(string methodName);
    }
    public class AuthorizeService :Base.ServiceBase, IAuthorizeService
    {
        private string Key, Issuer;
        private IHttpContextAccessor SetContext;

        public AuthorizeService(IConfiguration configuration, IHttpContextAccessor setContext, ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper):base(cacheService, serviceCaller, clientFactory, mapper)
        {
        
            Key = configuration.GetSection("Key").Value;
            Issuer = configuration.GetSection("Issuer").Value;
            SetContext = setContext;

        }

        private JwtSecurityToken ValidateToken(string token)
        {

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = Issuer,
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

        private void SetHttpContext(BehsamFramework.Models.LoginModel model)
        {
            if(model==null)
            { 
                return;
            }

            if(string.IsNullOrEmpty( model.Token))
            {
                return;
            }

            var validate = ValidateToken(model.Token);

            if(validate==null)
            {
                return;
            }

            var appId= validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "ApplicationId".ToLower()).Value;
            var userId = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "UserId".ToLower()).Value;
            var store = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "StoreId".ToLower()).Value;
            var name = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "Name".ToLower()).Value;
            var phoneNumber = validate.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "PhoneNumber".ToLower()).Value;

            Models.UserModel user = new Models.UserModel()
            {
                UserId=Convert.ToInt32( userId),
                StoreId=store,
                Name=name,
                ApplicationId=Convert.ToInt32(appId),
                PhoneNumber=phoneNumber,
                Token=model.Token
            };
            
            
            SetContext.HttpContext.Items["User"]=user ;
            SetContext.HttpContext.Session.Set<Models.UserModel>("User", user);
            SetContext.HttpContext.Items["AuthorizeService"] = this;
            SetContext.HttpContext.Session.Set<AuthorizeService>("AuthorizeService", this);

            SetContext.HttpContext.Session.Set<Models.UserModel>("User", user);
            SetContext.HttpContext.Session.Set<AuthorizeService>("AuthorizeService", this);
        }

        public FluentResult Login(long userName,string password,int appllicationId)
        {
            FluentResult<BehsamFramework.Models.LoginModel> result =
                new FluentResult<BehsamFramework.Models.LoginModel>();

            if(userName<1 || appllicationId<1 || string.IsNullOrEmpty(password))
            {
                result.WithError("اطلاعات صحیح نمی باشد");
                return result;
            }

            var command = new
            {
                UserName = userName,
                ApplicationId = appllicationId,
                Password = password
            };

            result = ServiceCaller.PostDataWithValue<BehsamFramework.Models.LoginModel>("loginUser/LoginUser", command).Result;
            
            if(result == null || result.Value==null || string.IsNullOrEmpty( result.Value.Token))
            {
                result =new FluentResult<BehsamFramework.Models.LoginModel>();
                result.WithError("اطلاعات صحیح نمی باشد");
                return result;
            }

            if(result.IsSuccess )
            {
                SetHttpContext(result.Value);
            }

            return result;
        }

        public FluentResult CheckAccess(string methodName)
        {
            FluentResult result = new FluentResult();

            try
            {


                if (string.IsNullOrEmpty(methodName))
                {
                    result.WithError("دسترسی ندارید");
                    return result;
                }

                Models.UserModel user = SetContext.HttpContext.Items["User"] as Models.UserModel;
                if (user == null)
                {
                    result.WithError("اطلاعات کاربر یافت نشد");
                    return result;
                }

                var validateToken = ValidateToken(user.Token);
                if (validateToken == null)
                {
                    result.WithError("توکن کاربر نامعتبر است");
                    return result;
                }

                var command = new
                {
                    UserId = user.UserId,
                    ApplicationId = user.ApplicationId,
                    MethodName = methodName
                };

                result = ServiceCaller.PostDataWithValue<BehsamFramework.Models.LoginModel>("loginUser/UserAccess", command).Result;

                if (result == null)
                {
                    result = new FluentResult();
                    result.WithError("اطلاعات صحیح نمی باشد");
                    return result;
                }

               
            }
            catch(Exception ex)
            {
                result = new FluentResult();
                result.WithError("خطای غیر منتظره: " + ex.Message);
            }

            return result;
        }
    }

    
}
