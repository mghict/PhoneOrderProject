using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;

namespace WebSite.JourChin.Controllers.Base
{

    public class BaseController : Controller
    {


        protected ICachedMemoryService CacheService;

        protected IHttpClientFactory ClientFactory;

        protected ServiceCaller ServiceCaller;

        protected AutoMapper.IMapper Mapper;
        public BaseController(
            ServiceCaller serviceCaller, ICachedMemoryService _cacheService, AutoMapper.IMapper mapper) : base()
        {

            ServiceCaller = serviceCaller;
            CacheService = _cacheService;
            Mapper = mapper;

            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var user=context.HttpContext?.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                ServiceCaller.SetToken(user.Token);
            }
        }

        protected void SetUserToken()
        {

            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                ServiceCaller.SetToken(user.Token);
            }

            return;

        }
    }
}