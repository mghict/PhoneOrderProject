using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UserAuthorize.Application.Token
{
    public interface ITokenCreate
    {
        string GenerateJWTToken(Domain.Entities.UserInfoTbl userInfo, int applicationId);
        Task<TokenValidateModel> ValidateUserToken(string token);
    }

    public class TokenCreate: ITokenCreate
    {
        private readonly string _key;
        private readonly string _issuer;
        public TokenCreate(string key,string issuer)
        {
            //_key = "Mgh@994500522646! ";
            //_issuer = "BehsamCo.com";
            _key = key;
            _issuer = issuer;
        }

        public string GenerateJWTToken(Domain.Entities.UserInfoTbl userInfo,int applicationId)
        {   //_Configuration["JWTSecurity:key"] _Configuration["JWTSecurity:Issuer"]
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var permClaims = GetClaim(userInfo,applicationId);

            var token = new JwtSecurityToken(_issuer,
                _issuer,
                permClaims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials
            );

            var result= new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        private List<Claim> GetClaim(Domain.Entities.UserInfoTbl userInfo,int applicationId)
        {
            var permClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", userInfo.Id.ToString()),
                new Claim("StoreId", userInfo.StoreId==null ? "":userInfo.StoreId?.ToString(CultureInfo.InvariantCulture)),
                new Claim("Name", string.Format("{0}", userInfo.Name)),
                new Claim("PhoneNumber",userInfo.UserName.ToString("00000000000")),
                new Claim("ApplicationId",applicationId.ToString())
            };

            return permClaims;
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

        public async Task<TokenValidateModel> ValidateUserToken(string token)
        {
            TokenValidateModel result = new TokenValidateModel();
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    return result;
                }

                var _validateToken = await ValidateToken(token);
                if (_validateToken == null)
                {
                    return result;
                }

                var userid = _validateToken.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "UserId".ToLower()).Value;
                if (string.IsNullOrEmpty(userid))
                {
                    return result;
                }

                var appid = _validateToken.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "ApplicationId".ToLower()).Value;
                if (string.IsNullOrEmpty(appid))
                {
                    return result;
                }

                int userId = Convert.ToInt32(userid);
                int applicationId= Convert.ToInt32(appid);

                result.ApplicationId = applicationId;
                result.UserId = userId;

                return result;
            }
            catch (Exception e)
            {
                return new TokenValidateModel();
            }

        }
    }
}
