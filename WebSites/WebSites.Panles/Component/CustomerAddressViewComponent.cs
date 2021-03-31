using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Component
{
    [ViewComponent(Name = "CustomerAddressVC")]
    public class CustomerAddressViewComponent:ViewComponent
    {
        protected IMemoryCache _memoryCache;

        protected ICacheService CacheService;

        protected IHttpClientFactory ClientFactory;

        protected ServiceCaller serviceCaller;

        protected StaticValues staticValues;

        public CustomerAddressViewComponent(IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues StaticValues) //: base(memoryCache, _clientFactory, _cacheService, StaticValues)
        {
            staticValues = StaticValues;
            _memoryCache = memoryCache;
            ClientFactory = _clientFactory;
            serviceCaller = new ServiceCaller(ClientFactory);
            CacheService = _cacheService;
        }
       
        public  IViewComponentResult Invoke(long customerId)
        {
            var model =  GetAddresses(customerId).Result;

            return View(model);
        }

        private async Task<List<BehsamFramework.Models.CustomerAddressModel>> GetAddresses(long customerId)
        {
            var model = await Task.Run(() =>
            {
                List<BehsamFramework.Models.CustomerAddressModel> ret =
                    new List<BehsamFramework.Models.CustomerAddressModel>();

                string cashedKey = "CustomerAddress" + customerId;

                try
                {
                    ret = CacheService.GetOrSet(ret,
                        customerId,
                        cashedKey,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        CacheItemPriority.Low,
                        TokenCachClass.CustomerAddressesAdd,
                        GetCustomerAddresses);

                }
                catch 
                {
                    ret = new List<BehsamFramework.Models.CustomerAddressModel>();
                }

                return ret;
            });

            return model;
        }

        private List<BehsamFramework.Models.CustomerAddressModel> GetCustomerAddresses(long customerId)
        {

            FluentResult<List<BehsamFramework.Models.CustomerAddressModel>> model =
                new FluentResult<List<BehsamFramework.Models.CustomerAddressModel>>();

            try
            {
                model = serviceCaller.GetDataWithValue<List<BehsamFramework.Models.CustomerAddressModel>>("Address/GetCustomerAddresses?id=" + customerId).Result;

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<BehsamFramework.Models.CustomerAddressModel>>();
                model.WithError(ex.Message);
            }

            return model.Value;
        }

    }
}
