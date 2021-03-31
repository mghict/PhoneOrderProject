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
    public class GetCustomerBySearch : Base.ServiceBase, IGetCustomerBySearch
    {
        public GetCustomerBySearch(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task< Models.Customer.CustomerInfoModel> GetCustomerInfoAsync(string searckKey)
        {
            Models.Customer.CustomerInfoModel ret = new Models.Customer.CustomerInfoModel();

            ret = await GetCustomerInfo(searckKey);

            return ret;
        }
        private async Task<Models.Customer.CustomerInfoModel> GetCustomerInfo(string searckKey)
        {
            Models.Customer.CustomerInfoModel retVal = 
                new Models.Customer.CustomerInfoModel();
            try
            {
                var result = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerInfoModel>("Customer/GetCustomerBySearch",new { SearchKey = searckKey });
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
            catch (Exception ex)
            {

                return null;
            }

        }
    }

    public interface IGetCustomerBySearch
    {
        Task<Models.Customer.CustomerInfoModel> GetCustomerInfoAsync(string searckKey);
        
    }
}
