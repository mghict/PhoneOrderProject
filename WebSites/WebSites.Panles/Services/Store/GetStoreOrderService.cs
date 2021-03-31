using AutoMapper;
using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Store
{
    public interface IGetStoreOrderService
    {
        Task<List<BehsamFramework.Models.StoreOrderModel>> GetStores(TimeSpan startTime,TimeSpan endTime,DateTime requestDate,long customerId);
    }

    public class GetStoreOrderService : Base.ServiceBase, IGetStoreOrderService
    {
        public GetStoreOrderService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<StoreOrderModel>> GetStores(TimeSpan startTime, TimeSpan endTime, DateTime requestDate, long customerId)
        {
            List<StoreOrderModel> ret = await GetStoreService(startTime, endTime, requestDate, customerId);

            if (ret == null)
            {
                ret = new List<StoreOrderModel>();
            }

            return ret;
        }
        private async Task<List<StoreOrderModel>> GetStoreService(TimeSpan startTime, TimeSpan endTime, DateTime requestDate, long customerId)
        {
            List<StoreOrderModel> result = new List<StoreOrderModel>();

            var Command = new
            {
                RequestDate = requestDate,
                StartTime=startTime,
                EndTime= endTime,
                CustomerId=customerId
            };

            FluentResult<List<BehsamFramework.Models.StoreOrderModel>> model =
                new FluentResult<List<StoreOrderModel>>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<List<StoreOrderModel>>("Setting/StoreOrder", Command);


                if (model == null || model.Value == null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<StoreOrderModel>>()
                {
                    Value = new List<StoreOrderModel>()
                };
                model.WithError(ex.Message);
            }

            return model.Value;
        }
    }
}
