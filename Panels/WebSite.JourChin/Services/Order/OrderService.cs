using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;

namespace WebSite.JourChin.Services.Order
{
    public interface IOrderService
    {
        Task<FluentResults.Result> ChangeOrderStatus(long orderCode, byte status, string reason);
        Task<FluentResults.Result<Models.Order.GetOrderInfoWithItems>> GetOrderInfoWithItems(long orderCode);
        Task<FluentResults.Result<bool>> AcceptUserForOrderItems(long orderId, long itemId);

        Task<FluentResults.Result<bool>> FirstStateUserForOrderItems(long orderId, long itemId);
        
        Task<FluentResults.Result<bool>> ReplaceStateUserForOrderItems(long orderId, long itemId);

        Task<FluentResults.Result<bool>> ChangeStateUserForOrderItems(long orderId, long itemId, int state);

        //-----------------------------------------------------------------
        // OrderItemsReverse
        //-----------------------------------------------------------------

        Task<FluentResults.Result<long>> CreateItemReserveAsync(long orderItemId, int productId);
        Task<FluentResults.Result<bool>> UpdateItemReserveAsync(long id, long orderItemId, int productId, bool status);
        Task<FluentResults.Result<bool>> DeleteItemReserveAsync(long id);
        Task<FluentResults.Result<List<BehsamFramework.Models.OrderItemsReserveModel>>> GetItemReserveDetailsAsync(long id);
    }
    public class OrderService : Base.ServiceBase, IOrderService
    {
        public OrderService(ICachedMemoryService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<FluentResults.Result> ChangeOrderStatus(long orderCode,byte status,string reason)
        {
            FluentResults.Result result = new FluentResults.Result();

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

        public async Task<FluentResults.Result<Models.Order.GetOrderInfoWithItems>> GetOrderInfoWithItems(long orderCode)
        {
            var command = new
            {
                OrderCode = orderCode
            };

            var result = await ServiceCaller.PostDataWithValue<Models.Order.GetOrderInfoWithItems>("Order/Order/GetOrderInfoWithItems", command);

            return result;
        }

        public async Task<FluentResults.Result<bool>> AcceptUserForOrderItems(long orderId,long itemId)
        {
            var command = new
            {
                OrderId = orderId,
                ItemId=itemId
            };

            var result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/AcceptUserForOrderItems", command);

            return result;
        }

        public async Task<FluentResults.Result<bool>> FirstStateUserForOrderItems(long orderId, long itemId)
        {
            var command = new
            {
                OrderId = orderId,
                ItemId = itemId
            };

            var result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/FirstStateUserForOrderItems", command);

            return result;
        }

        public async Task<FluentResults.Result<bool>> ReplaceStateUserForOrderItems(long orderId, long itemId)
        {
            var command = new
            {
                OrderId = orderId,
                ItemId = itemId
            };

            var result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/ReplaceStateUserForOrderItems", command);

            return result;
        }

        public async Task<FluentResults.Result<bool>> ChangeStateUserForOrderItems(long orderId, long itemId,int state)
        {
            var command = new
            {
                OrderId = orderId,
                ItemId = itemId,
                State=state
            };

            var result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/ChangeStateUserForOrderItems", command);

            return result;
        }

        //-----------------------------------------------------------------
        // OrderItemsReverse
        //-----------------------------------------------------------------

        public async Task<FluentResults.Result<long>> CreateItemReserveAsync(long orderItemId,int productId)
        {
            FluentResults.Result<long> result = new FluentResults.Result<long>();
            result.WithValue(0);
            var command = new
            {
                OrderItemId = orderItemId,
                ProductId = productId
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<long>("Order/Order/CreateItemReserve", command);
            }
            catch (Exception ex)
            {
                result.WithValue(0);
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<FluentResults.Result<bool>> UpdateItemReserveAsync(long id,long orderItemId, int productId,bool status)
        {
            FluentResults.Result<bool> result = new FluentResults.Result<bool>();
            result.WithValue(false);
            var command = new
            {
                Id=id,
                OrderItemId = orderItemId,
                ProductId = productId,
                Status=status
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue< bool>("Order/Order/UpdateItemReserve", command);
            }
            catch (Exception ex)
            {
                result.WithValue(false);
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<FluentResults.Result<bool>> DeleteItemReserveAsync(long id)
        {
            FluentResults.Result<bool> result = new FluentResults.Result<bool>();
            result.WithValue(false);
            var command = new
            {
                Id = id
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/DeleteItemReserve", command);
            }
            catch (Exception ex)
            {
                result.WithValue(false);
                result.WithError(ex.Message);
            }

            return result;
        }
        public async Task<FluentResults.Result<List<BehsamFramework.Models.OrderItemsReserveModel>>> GetItemReserveDetailsAsync(long id)
        {
            FluentResults.Result<List<BehsamFramework.Models.OrderItemsReserveModel>> result = new FluentResults.Result<List<BehsamFramework.Models.OrderItemsReserveModel>>();

            var command = new
            {
                ItemId = id
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue< List<BehsamFramework.Models.OrderItemsReserveModel>>("Order/Order/GetOrderItemsReserve", command);
            }
            catch (Exception ex)
            {
                result.WithValue(new List<BehsamFramework.Models.OrderItemsReserveModel>());
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
