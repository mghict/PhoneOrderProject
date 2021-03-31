using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;


namespace BehsamFramework.Attributes.Authorize
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute:
        System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
                if (descriptor == null)
                {
                    result.WithError("خطای دسترسی");

                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };

                    return;
                }

                string MethodName = descriptor.ActionName;
                string ControllerName = descriptor.ControllerName;

                Entity.UserInfoTbl user =
                    context.HttpContext.Items["User"] as Entity.UserInfoTbl;

                DapperDomain.UnitOfWork unitOfWork =
                    context.HttpContext.Items["UnitOfWork"] as DapperDomain.UnitOfWork;

                if (user == null)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("کاربر لاگین نکرده است");

                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };

                    return;
                }

                if (unitOfWork == null)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("شی اتصال وجود ندارد");

                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status502BadGateway
                        };

                    return;
                }
                var access = await unitOfWork.AuthorizeRepository.IsValidAccessAsync(user.Id, ControllerName, MethodName);

                if (!access)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("کاربر دسترسی به عملیات را ندارد");
                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable
                        };

                    return;
                }
            }
            catch (Exception e)
            {
                result.WithError("خطای دسترسی");
                result.WithError(e.Message);
                context.Result =
                    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
            }

        }
    }
}
