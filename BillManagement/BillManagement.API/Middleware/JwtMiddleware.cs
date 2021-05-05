using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;

namespace BillManagement.Middleware
{
    public class JwtMiddleware:object
    {
        private Application.Token.ITokenCreate TokenSecurity { get; }
        public JwtMiddleware
        (
            Microsoft.AspNetCore.Http.RequestDelegate next,
            Application.Token.ITokenCreate tokenSecurity
        ) : base()
        {
            Next = next;
            TokenSecurity = tokenSecurity;
        }

        
        protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

        public async Task Invoke
        (
            Microsoft.AspNetCore.Http.HttpContext context
        )
        {
            var path = context.Request.Path.ToString();
            if(path.ToLower().Contains("login".ToLower()))
            {
                await Next(context);
            }
            else
            {


                FluentResults.Result result = new FluentResults.Result();

                var requestHeader = context.Request.Headers["Authorization"];
                string token = requestHeader.ToString().Replace("Bearer", string.Empty).Trim(); //requestHeader.FirstOrDefault()?.Split(".").Last();

                result = await TokenSecurity.ValidateUserToken(token);

                if (result.IsSuccess)
                {
                    await Next(context);
                }
                else
                {
                    await context.Response.WriteAsJsonAsync(result);
                }
            }
        }

    }
}
