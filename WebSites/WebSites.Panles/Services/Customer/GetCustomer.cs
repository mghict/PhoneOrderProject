using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Customer
{
    public class GetCustomer : Base.ServiceBase,IGetCustomer
    {
        public GetCustomer(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task< Models.Customer.CustomerInfoModel> GetCustomerInfoAsync(long customerId)
        {
            Models.Customer.CustomerInfoModel ret = new Models.Customer.CustomerInfoModel();
            string Key = "CustomerInfo" + customerId.ToString();

            ret =await CacheService.GetOrSetAsync< Models.Customer.CustomerInfoModel,long>
                ( ret,
                customerId,
                Key,
                TimeSpan.FromHours(2),
                TimeSpan.FromMinutes(10),
                CacheItemPriority.Low,
                TokenCachClass.CustomerList,
                GetCustomerInfo);

            return ret;
        }
        private async Task<Models.Customer.CustomerInfoModel> GetCustomerInfo(long customerId)
        {
            Models.Customer.CustomerInfoModel retVal = 
                new Models.Customer.CustomerInfoModel();
            try
            {
                var result = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerInfoModel>("Customer/GetById",new { Id = customerId });
                if (result.IsSuccess)
                {
                    retVal = Mapper.Map<Models.Customer.CustomerInfoModel>(result.Value);
                    return retVal;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            }

        }
    }

    public interface IGetCustomer 
    {
        Task<Models.Customer.CustomerInfoModel> GetCustomerInfoAsync(long customerId);
        
    }
}
