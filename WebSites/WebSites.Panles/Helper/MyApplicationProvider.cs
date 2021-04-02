using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using WebSites.Panles.Services.Authorize;

namespace WebSites.Panles.Helper
{
    public class MyApplicationProvider : IApplicationModelProvider
    {
        private Services.Authorize.IAuthorizeService authorizeService;

        public MyApplicationProvider(IAuthorizeService authorizeService)
        {
            this.authorizeService = authorizeService;
        }

        public int Order { get { return -1000 + 10; } }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            foreach (var controllerModel in context.Result.Controllers)
            {
                // pass the depencency to controller attibutes
                controllerModel.Attributes
                    .OfType<Authorize.CustomAuthorizeAttribute>().ToList()
                    .ForEach(a => a._AuthorizeService = authorizeService);

                controllerModel.Attributes
                    .OfType<Authorize.CustomAjaxAuthorizeAttribute>().ToList()
                    .ForEach(a => a._AuthorizeService = authorizeService);

                // pass the dependency to action attributes
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<Authorize.CustomAuthorizeAttribute>().ToList()
                    .ForEach(a => a._AuthorizeService = authorizeService);

                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<Authorize.CustomAjaxAuthorizeAttribute>().ToList()
                    .ForEach(a => a._AuthorizeService = authorizeService);
            }
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
           
        }
    }
}
