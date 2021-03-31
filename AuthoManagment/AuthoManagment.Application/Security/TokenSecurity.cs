using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace AuthoManagment.Application.Security
{
    public class TokenSecurity : ITokenSecurity
    {
        private readonly string _key;
        private readonly string _issuer;
        public TokenSecurity()
        {
            _key = "Mgh@994500522646! ";
            _issuer = "BehsamCo.com";
        }

        public string GenerateJWTToken(AuthoManagment.Domain.Entities.UserInfoTbl userInfo)
        {   //_Configuration["JWTSecurity:key"] _Configuration["JWTSecurity:Issuer"]
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var permClaims = GetClaim(userInfo);

            var token = new JwtSecurityToken(_issuer,
                _issuer,
                permClaims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetClaim(AuthoManagment.Domain.Entities.UserInfoTbl userInfo)
        {
            var permClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", userInfo.Id.ToString()),
                new Claim("UserName", userInfo.UserName??""),
                new Claim("FullName", string.Format("{0} {1}", userInfo.FirstName, userInfo.LastName)),
                new Claim("PhoneNumber",
                    string.IsNullOrEmpty(userInfo.PhoneNumber.ToString())
                        ? string.Empty
                        : userInfo.PhoneNumber.ToString("00000000000"))
            };

            return permClaims;
        }
        /*public int AccessInOperation(DTOs.Input.UserInfo.UserAccessDto userAccess)
        {
            if (string.IsNullOrEmpty(userAccess.OperationName))
            {
                throw new Exception(GeneralMessages.Input_NotValid);
            }

            if (string.IsNullOrEmpty(userAccess.Token))
            {
                throw new Exception(GeneralMessages.Input_NotValid);
            }

            var validatedToken = ValidateToken(userAccess.Token);

            if (validatedToken == null)
            {
                throw new Exception(GeneralMessages.Token_Invalid);
            }

            var userid = validatedToken.Claims.First(claim => claim.Type == "UserId").Value;
            if (string.IsNullOrEmpty(userid))
            {
                throw new Exception(GeneralMessages.Token_Invalid);
            }

            return Convert.ToInt32(userid);
        }
        
        private JwtSecurityToken ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(GeneralMessages.Input_Null);
            }

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
        }*/


    }
}
