using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebSites.Panles.Services.Authorize;
using Microsoft.AspNetCore.Routing;

namespace WebSites.Panles.Helper.Authorize
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAuthorizeAttribute:
        System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter
    {
        

        public CustomAuthorizeAttribute()
        {
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            FluentResult result = new FluentResult();

            try
            {
                var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;
                if (descriptor == null)
                {
                    result.WithError("خطای دسترسی");

                    //context.Result =
                    //    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                    //    {
                    //        StatusCode = StatusCodes.Status401Unauthorized
                    //    };

                    context.Result = new 
                        Microsoft.AspNetCore.Mvc.RedirectToRouteResult(
                            new  RouteValueDictionary(new { controller = "Home", action = "Index",area=""  })); 
                    //RedirectResult("/home/Index");

                    return;
                }

                string MethodName = descriptor.ActionName;
                string ControllerName = descriptor.ControllerName;

                Models.UserModel user =
                    context.HttpContext.Session.Get<Models.UserModel>("User");

                AuthorizeService Service =
                    context.HttpContext.Session.Get<AuthorizeService>("AuthorizeService");

                if(Service==null)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("شی دسترسی وجود ندارد");

                    //context.Result =
                    //    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                    //    {
                    //        StatusCode = StatusCodes.Status401Unauthorized
                    //    };

                    context.Result = new
                        Microsoft.AspNetCore.Mvc.RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));

                    return;
                }

                if (user == null)
                {
                    result.WithError("خطای دسترسی");
                    result.WithError("کاربر لاگین نکرده است");

                    //context.Result =
                    //    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                    //    {
                    //        StatusCode = StatusCodes.Status401Unauthorized
                    //    };
                    context.Result = new
                        Microsoft.AspNetCore.Mvc.RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
                    return;
                }

                result=Service.CheckAccess(ControllerName+"/"+MethodName);

                if(!result.IsSuccess)
                {
                    //context.Result =
                    //    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                    //    {
                    //        StatusCode = StatusCodes.Status401Unauthorized
                    //    };

                    context.Result = new
                        Microsoft.AspNetCore.Mvc.RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Home", action = "AccessDenied" }));
                    return;
                }

            }
            catch (Exception e)
            {
                result.WithError("خطای دسترسی");
                result.WithError(e.Message);
                //context.Result =
                //    new Microsoft.AspNetCore.Mvc.JsonResult(value: result)
                //    {
                //        StatusCode = StatusCodes.Status401Unauthorized
                //    };
                context.Result = new
                        Microsoft.AspNetCore.Mvc.RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Home", action = "AccessDenied" }));
                return;
            }

        }
    }
}
