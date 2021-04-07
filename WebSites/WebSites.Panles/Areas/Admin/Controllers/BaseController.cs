using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/[controller]")]

    public class BaseController : Controller
    {
        protected IMemoryCache _memoryCache;

        protected ICacheService CacheService;

        protected IHttpClientFactory ClientFactory;

        protected ServiceCaller ServiceCaller;

        protected StaticValues StaticValues;

        protected AutoMapper.IMapper Mapper;
        public BaseController(IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, AutoMapper.IMapper mapper) : base()
        {
            StaticValues = staticValues;
            _memoryCache = memoryCache;
            ClientFactory = _clientFactory;
            ServiceCaller = new ServiceCaller(ClientFactory);
            CacheService = _cacheService;
            Mapper = mapper;
        }
    }
}