using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.CustomerPhone
{
    public interface IGetPhoneByIdService
    {
        Task<Models.CustomerPhone.CustomerPhoneModel> Execute(long phoneId);
        Task<Models.CustomerPhone.CustomerPhoneUpdateModel> ExecuteUpdateModel(long phoneId);
    }
    public class GetPhoneByIdService : Base.ServiceBase, IGetPhoneByIdService
    {
        public GetPhoneByIdService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<Models.CustomerPhone.CustomerPhoneModel> Execute(long phoneId)
        {
            if (phoneId > 0)
            {
                var result = await GetPhone(phoneId);
                if (result == null)
                {
                    return new Models.CustomerPhone.CustomerPhoneModel();
                }

                var resp = Mapper.Map<Models.CustomerPhone.CustomerPhoneModel>(result);
                return resp;
            }
            else
            {
                return new Models.CustomerPhone.CustomerPhoneModel();
            }
        }

        public async Task<Models.CustomerPhone.CustomerPhoneUpdateModel> ExecuteUpdateModel(long phoneId)
        {
            if (phoneId > 0)
            {
                var result = await GetPhone(phoneId);
                if (result == null)
                {
                    return new Models.CustomerPhone.CustomerPhoneUpdateModel();
                }

                var resp = Mapper.Map<Models.CustomerPhone.CustomerPhoneUpdateModel>(result);
                return resp;
            }
            else
            {
                return new Models.CustomerPhone.CustomerPhoneUpdateModel();
            }
        }

        private async Task<BehsamFramework.Models.CustomerPhoneModel> GetPhoneById(long phoneId)
        {

            var Command = new
            {
                Id = phoneId
            };

            FluentResult<BehsamFramework.Models.CustomerPhoneModel> model =
                new FluentResult<BehsamFramework.Models.CustomerPhoneModel>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerPhoneModel>("phone/GetById", Command);
                if(model==null || model.Value==null)
                {
                    model= new FluentResult<BehsamFramework.Models.CustomerPhoneModel>();
                }
            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.CustomerPhoneModel>();
                model.WithError(ex.Message);
            }

            return model.Value;

        }

        private async Task<BehsamFramework.Models.CustomerPhoneModel> GetPhone(long phoneId)
        {
            BehsamFramework.Models.CustomerPhoneModel ret =
                new BehsamFramework.Models.CustomerPhoneModel();

            string cashedKey = "PhoneGet" + phoneId;

            try
            {
                ret = await CacheService.GetOrSetAsync
                    (ret,
                    phoneId,
                    cashedKey,
                    TimeSpan.FromMinutes(10),
                    TimeSpan.FromMinutes(5),
                    CacheItemPriority.Low,
                    TokenCachClass.CustomerPhonesAdd,
                    GetPhoneById);

            }
            catch (Exception ex)
            {
                ret = new BehsamFramework.Models.CustomerPhoneModel();
            }

            return ret;

        }
    }
}
