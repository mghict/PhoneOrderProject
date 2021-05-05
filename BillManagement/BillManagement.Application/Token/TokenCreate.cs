using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BillManagement.Application.Token
{
    public interface ITokenCreate
    {
        Task<FluentResults.Result<string>> GenerateJWTToken(string userName, string password);
        Task<FluentResults.Result> ValidateUserToken(string token);
    }

    public class TokenCreate : ITokenCreate
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _userName;
        private readonly string _password;

        public TokenCreate(string key, string issuer, string userName, string password)
        {
            _key = key;
            _issuer = issuer;
            _userName = userName;
            _password = password;
        }

        public async Task<FluentResults.Result<string>> GenerateJWTToken(string userName, string password)
        {
            FluentResults.Result<string> result = new FluentResults.Result<string>();

            if (_userName.Trim().Equals(userName) && _password.Trim().Equals(password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                var permClaims = await GetClaim(userName);

                var token = new JwtSecurityToken(_issuer,
                    _issuer,
                    permClaims,
                    expires: DateTime.Now.AddHours(12),
                    signingCredentials: credentials
                );

                result.WithValue(new JwtSecurityTokenHandler().WriteToken(token));
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            else
            {
                result.WithValue(string.Empty);
                result.WithError(BehsamFramework.Resources.Messages.UserNamePassNotFound);
            }

            return result;
        }

        private async Task<List<Claim>> GetClaim(string userName)
        {
            return await Task.Run(() =>
            {
                var permClaims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", userName.Trim())
                };

                return permClaims;
            });

        }

        private async Task<JwtSecurityToken> ValidateToken(string token)
        {
            return await Task.Run(() =>
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
            });

        }

        public async Task<FluentResults.Result> ValidateUserToken(string token)
        {
            FluentResults.Result result = new FluentResults.Result();
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    return result.WithError(BehsamFramework.Resources.Messages.TokenNotValid);
                }

                var _validateToken = await ValidateToken(token);
                if (_validateToken == null)
                {
                    return result.WithError(BehsamFramework.Resources.Messages.TokenNotValid);
                }

                var user = _validateToken.Claims.FirstOrDefault(claim => claim.Type.ToLower() == "UserName".ToLower()).Value;
                if (string.IsNullOrEmpty(user))
                {
                    return result.WithError(BehsamFramework.Resources.Messages.TokenNotValid);
                }

                if (!user.Trim().Equals(_userName))
                {
                    return result.WithError(BehsamFramework.Resources.Messages.TokenNotValid);
                }

                return result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);

            }
            catch (Exception e)
            {
                return result.WithError(BehsamFramework.Resources.Messages.TokenNotValid + " " + Environment.NewLine + e.Message);
            }

        }
    }
}
