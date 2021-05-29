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
        Task<FluentResult<List<Models.Order.OrderByStatusItem>>> GetOrderByStatusItem(int status, int itemStatus, int userId = 0);
        Task<FluentResult<List<BehsamFramework.Models.OrderItemsReserveModel>>> GetItemReserveDetailsAsync(long id);
        Task<FluentResult> ReplaceProductToOrderAcceptAsync(long itemId, int productId, int count = 0);
        Task<FluentResult<bool>> DeleteItemReserveAsync(long id);
        Task<FluentResult<bool>> ChangeStateUserForOrderItems(long orderId, long itemId, int state);

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

        public async Task<FluentResult<List<Models.Order.OrderByStatusItem>>> GetOrderByStatusItem(int status, int itemStatus, int userId = 0)
        {
            FluentResult<List<Models.Order.OrderByStatusItem>> result = new FluentResult<List<Models.Order.OrderByStatusItem>>();
            result.IsFailed = true;

            var command = new
            {
                UserId = userId,
                Status = status,
                ItemStatus = itemStatus
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<List<Models.Order.OrderByStatusItem>>("Order/Order/GetOrderByStatusItem", command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult<List<BehsamFramework.Models.OrderItemsReserveModel>>> GetItemReserveDetailsAsync(long id)
        {
            FluentResult<List<BehsamFramework.Models.OrderItemsReserveModel>> result = new FluentResult<List<BehsamFramework.Models.OrderItemsReserveModel>>();

            var command = new
            {
                ItemId = id
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<List<BehsamFramework.Models.OrderItemsReserveModel>>("Order/Order/GetOrderItemsReserve", command);
            }
            catch (Exception ex)
            {
                result.WithValue(new List<BehsamFramework.Models.OrderItemsReserveModel>());
                result.WithError(ex.Message);
            }

            return result;
        }
        //
        public async Task<FluentResult> ReplaceProductToOrderAcceptAsync(long itemId,int productId,int count=0)
        {
            FluentResult result = new FluentResult();
            result.IsFailed = true;

            var command = new
            {
                OrginalItemId = itemId,
                ReplaceProductId= productId,
                Count= count
            };

            try
            {
                result = await ServiceCaller.PostDataWithoutValue("Order/Order/ReplaceProductToOrderAccept", command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult<bool>> DeleteItemReserveAsync(long id)
        {
            FluentResult<bool> result = new FluentResult<bool>();
            result.WithValue(false);
            var command = new
            {
                Id = id
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/DeleteItemReserve", command);
                if (result != null && result.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.CachedOrderToken);
                }
            }

            catch (Exception ex)
            {
                result.WithValue(false);
                result.WithError(ex.Message);
            }

            return result;
        }

        public async Task<FluentResult<bool>> ChangeStateUserForOrderItems(long orderId, long itemId, int state)
        {
            var command = new
            {
                OrderId = orderId,
                ItemId = itemId,
                State = state
            };

            var result = await ServiceCaller.PostDataWithValue<bool>("Order/Order/ChangeStateUserForOrderItems", command);

            if (result != null && result.IsSuccess)
            {
                await CacheService.ClearTokenAsync(TokenCachClass.CachedOrderToken);
            }

            return result;
        }


    }
}
