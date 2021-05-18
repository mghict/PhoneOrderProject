using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebSite.JourChin.Services.Authorize;
using Microsoft.AspNetCore.Routing;

namespace WebSite.JourChin.Helper.Authorize
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAjaxAuthorizeAttribute :
        System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    {

        public IAuthorizeService _AuthorizeService { get; set; }
        public CustomAjaxAuthorizeAttribute()
        {
        }

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
                string areaName = descriptor.RouteValues["area"] as string;


                Models.UserModel user =
                    context.HttpContext.Session.Get<Models.UserModel>("User");


                if (_AuthorizeService == null)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("شی دسترسی وجود ندارد");

                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };


                    return;
                }

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

                result = _AuthorizeService.CheckAccess(ControllerName + "/" + MethodName);

                if (!result.IsSuccess)
                {
                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
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
                        StatusCode = StatusCodes.Status401Unauthorized
                    };

                return;
            }

        }
    }
}
