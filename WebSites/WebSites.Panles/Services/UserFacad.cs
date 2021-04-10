using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Services.Authorize;

namespace WebSites.Panles.Services
{
    public interface IUserFacad
    {
        Authorize.IApplicationService ApplicationService { get; }
    }
    public class UserFacad : Base.ServiceBase, IUserFacad
    {
        public UserFacad(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private IApplicationService _applicationService;
        public IApplicationService ApplicationService =>
            _applicationService = _applicationService ?? new Authorize.ApplicationService(CacheService, ServiceCaller, ClientFactory, Mapper);
    }
}
