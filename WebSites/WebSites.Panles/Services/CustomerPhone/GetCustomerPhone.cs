using AutoMapper;
using BehsamFramework.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.CustomerPhone
{
    public interface IGetCustomerPhone
    {
        Task<List<Models.CustomerPhone.CustomerPhoneModel>> Execute(long customerId);
    }
    public class GetCustomerPhone : Base.ServiceBase, IGetCustomerPhone
    {
        public GetCustomerPhone(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<Models.CustomerPhone.CustomerPhoneModel>> Execute(long customerId)
        {
            if (customerId > 0)
            {
                var result= await GetPhones(customerId);
                if(result==null)
                {
                    return new List<Models.CustomerPhone.CustomerPhoneModel>();
                }

                var resp = Mapper.Map<List<Models.CustomerPhone.CustomerPhoneModel>>(result);
                return resp;
            }
            else
            {
                return new List<Models.CustomerPhone.CustomerPhoneModel>();
            }
        }

        private async Task<List<BehsamFramework.Models.CustomerPhoneModel>> GetCustomerPhones(long customerId)
        {
            //var Command = new
            //{
            //    Id = customerId
            //};

            FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>> model =
                new FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>>();

            try
            {
                model = await ServiceCaller.GetDataWithValue<List<BehsamFramework.Models.CustomerPhoneModel>>("Phone/GetCustomerPhones?id="+ customerId);
                if(model.Value==null)
                {
                    model.Value = new List<CustomerPhoneModel>();
                }
            }
            catch (Exception ex)
            {
                model = new FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>>();
                model.WithError(ex.Message);

                

            }

            return model.Value;

        }

        private async Task<List<BehsamFramework.Models.CustomerPhoneModel>> GetPhones(long customerId)
        {
            List<BehsamFramework.Models.CustomerPhoneModel> ret =
                new List<BehsamFramework.Models.CustomerPhoneModel>();

            string cashedKey = "CustomerPhone" + customerId;

            try
            {
                ret = await CacheService.GetOrSetAsync
                    (ret,
                    customerId,
                    cashedKey,
                    TimeSpan.FromMinutes(10),
                    TimeSpan.FromMinutes(5),
                    CacheItemPriority.Low,
                    TokenCachClass.CustomerPhonesAdd,
                    GetCustomerPhones);

            }
            catch (Exception ex)
            {
                ret = new List<BehsamFramework.Models.CustomerPhoneModel>();
            }

            return ret;

        }
    }
}
