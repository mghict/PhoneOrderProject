using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Base
{
    public class ServiceBase
    {
        protected ICacheService CacheService;
        protected ServiceCaller ServiceCaller;
        protected IHttpClientFactory ClientFactory;
        protected AutoMapper.IMapper Mapper;

        public ServiceBase(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper)
        {
            CacheService = cacheService;
            ClientFactory = clientFactory;
            ServiceCaller = new ServiceCaller(ClientFactory);
            Mapper = mapper;
        }
    }
}
