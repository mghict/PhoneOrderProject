using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Gateway.TelOrderAPI.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;

namespace Gateway.TelOrderAPI.Middleware
{
    public class JwtMiddleware:object
    {
        public JwtMiddleware
        (
            Microsoft.AspNetCore.Http.RequestDelegate next,
            Security.ITokenSecurity tokenSecurity
        ) : base()
        {
            Next = next;
            TokenSecurity = tokenSecurity;
        }

        protected ITokenSecurity TokenSecurity { get; }
        protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

        public async Task Invoke
        (
            Microsoft.AspNetCore.Http.HttpContext context
        )
        {
            var path = context.Request.Path.ToString();
            if(path.ToLower().Contains("login/login-async".ToLower()))
            {
                await Next(context);
            }
            else
            {


                FluentResults.Result result = new FluentResults.Result();

                var requestHeader = context.Request.Headers["Authorization"];
                string token = requestHeader.ToString().Replace("Bearer", string.Empty)
                    .Trim(); //requestHeader.FirstOrDefault()?.Split(".").Last();

                if (!string.IsNullOrWhiteSpace(token))
                {
                    await TokenSecurity.AttachUserToContextByToken(context, token);

                    if (context.Items["User"] == null)
                    {


                        result.WithError("خطای کلید ارسالی");

                        await context.Response.WriteAsJsonAsync(result);
                    }
                    else
                    {
                        await Next(context);
                    }
                }
                else
                {
                    result.WithError("خطای کلید ارسالی");

                    await context.Response.WriteAsJsonAsync(result);
                }
            }
        }

    }
}
