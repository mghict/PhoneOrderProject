using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Order
{
    public interface IOrderService
    {
        Task<FluentResult> ChangeOrderStatus(long orderCode, byte status, string reason);
    }
    public class OrderService : Base.ServiceBase, IOrderService
    {
        public OrderService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<FluentResult> ChangeOrderStatus(long orderCode,byte status,string reason)
        {
            FluentResult result = new FluentResult();
            result.IsFailed = true;

            var command = new
            {
                OrderCode=orderCode,
                Status=status,
                Reason=reason
            };

            try
            {
                result = await ServiceCaller.PostDataWithoutValue("Order/Order/ChangeOrderStatus", command);
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
