using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;


namespace Gateway.TelOrderAPI.Security
{
    public class TokenSecurity : ITokenSecurity
    {
        private readonly string _key;
        private readonly string _issuer;
        private BehsamFramework.DapperDomain.QueryUnitOfWork UnitOfWork { get; }
        public TokenSecurity()
        {
            _key = "Mgh@994500522646! ";
            _issuer = "BehsamCo.com";
        }

        private async Task<JwtSecurityToken> ValidateToken(string token)
        {

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = _issuer,
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

        public async Task AttachUserToContextByToken(HttpContext context, string token)
        {

                try
                {
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        return ;
                    }

                    var _validateToken =await ValidateToken(token);
                    if (_validateToken == null)
                    {
                        return ;
                    }

                    var userid = _validateToken.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "UserId".ToLower()).Value;
                    if (string.IsNullOrEmpty(userid))
                    {
                        return ;
                    }

                    int userId = Convert.ToInt32(userid);
                    var userInfo =await  UnitOfWork.AuthorizeRepository.GetUserAsync(userId);
                    if (userInfo == null)
                    {
                        return ;
                    }

                    if (userInfo.Status != 2)
                    {
                        return ;
                    }

                    context.Items["User"] = userInfo;
                    context.Items["UnitOfWork"] = UnitOfWork;

                }
                catch (Exception e)
                {
                    return ;
                }

        }

    }
}
