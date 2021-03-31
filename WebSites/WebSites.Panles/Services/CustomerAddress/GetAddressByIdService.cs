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
    public interface IGetAddressByIdService
    {
        Task<Models.CustomerAddress.CustomerAddressModel> ExecuteGetAddressById(long addressId);
    }
    public class GetAddressByIdService : Base.ServiceBase, IGetAddressByIdService
    {
        public GetAddressByIdService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<CustomerAddressModel> ExecuteGetAddressById(long addressId)
        {
            return await GetAddressCashed(addressId);
        }

        private async Task<BehsamFramework.Models.CustomerAddressModel> GetAddress(long addressId)
        {

            var Command = new
            {
                Id = addressId
            };

            FluentResult<BehsamFramework.Models.CustomerAddressModel> model =
                new FluentResult<BehsamFramework.Models.CustomerAddressModel>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerAddressModel>("Address/GetById", Command);
                if(model.IsFailed)
                {
                    model = new FluentResult<BehsamFramework.Models.CustomerAddressModel>();
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.CustomerAddressModel>();
                model.WithError(ex.Message);
            }

            return model.Value;

        }
        private async Task<CustomerAddressModel> GetAddressCashed(long addressId)
        {
            CustomerAddressModel model = new CustomerAddressModel();

            try
            {
                var result = await GetAddress(addressId);
                if(result==null)
                {
                    throw new Exception("");
                }

                var response = Mapper.Map<CustomerAddressModel>(result);
                if (response == null)
                {
                    throw new Exception("");
                }
                string key = "AddressValue" + addressId.ToString();

                model = await CacheService.GetOrSetAsync(
                        response,
                        key,
                        TimeSpan.FromMinutes(20),
                        TimeSpan.FromMinutes(5),
                        CacheItemPriority.Low,
                        TokenCachClass.CustomerAddressesAdd
                    );
            }
            catch(Exception ex)
            {
                model = new CustomerAddressModel();
            }

            return model;

        }
    }
}
