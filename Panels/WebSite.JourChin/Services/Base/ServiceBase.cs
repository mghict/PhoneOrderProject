using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;

namespace WebSite.JourChin.Services.Base
{
    public class ServiceBase:ControllerBase
    {
        protected ICachedMemoryService CacheService;
        protected ServiceCaller ServiceCaller;
        protected IHttpClientFactory ClientFactory;
        protected AutoMapper.IMapper Mapper;

        public ServiceBase(
            ICachedMemoryService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper)
        {
            CacheService = cacheService;
            ClientFactory = clientFactory;
            ServiceCaller = serviceCaller;// new ServiceCaller(ClientFactory);
            Mapper = mapper;
        }
    }
}
