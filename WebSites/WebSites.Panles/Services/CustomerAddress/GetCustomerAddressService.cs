using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Models.CustomerAddress;

namespace WebSites.Panles.Services.CustomerAddress
{
    public interface IGetCustomerAddressService
    {
        Task<List<Models.CustomerAddress.CustomerAddressModel>> ExecuteGetAddresses(long customerId);
    }
    public class GetCustomerAddressService : Base.ServiceBase, IGetCustomerAddressService
    {
        public GetCustomerAddressService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<CustomerAddressModel>> ExecuteGetAddresses(long customerId)
        {
            List<CustomerAddressModel> model = new List<CustomerAddressModel>();
            if(customerId>0)
            {
                var result =await GetAddresses(customerId);
                if(result==null || result.Count<1)
                {
                    return model;
                }

                var response = Mapper.Map<List<Models.CustomerAddress.CustomerAddressModel>>(result);
                if(response==null||response.Count<1)
                {
                    return model;
                }

                return response;
            }
            else
            { 
                return model; 
            }
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
                        TimeSpan.FromMinutes(30),
                        TimeSpan.FromMinutes(10),
                        CacheItemPriority.Low,
                        TokenCachClass.CustomerAddressesAdd,
                        GetCustomerAddresses);

                }
                catch (Exception ex)
                {
                    ret = new List<BehsamFramework.Models.CustomerAddressModel>();
                }

                return ret;
            });

            return model;
        }

        private List<BehsamFramework.Models.CustomerAddressModel> GetCustomerAddresses(long customerId)
        {
            var Command = new
            {
                Id = customerId
            };

            FluentResult<List<BehsamFramework.Models.CustomerAddressModel>> model =
                new FluentResult<List<BehsamFramework.Models.CustomerAddressModel>>();

            try
            {
                model = ServiceCaller.GetDataWithValue<List<BehsamFramework.Models.CustomerAddressModel>>("Address/GetCustomerAddresses?id=" + customerId).Result;
                
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
