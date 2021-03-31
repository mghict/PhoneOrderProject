using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Order
{
    public interface ICachedOrderService 
    {

        int AddItem(float storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime, int productId, float unitPrice, int count,string name);
        bool UpdateItem(float storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime, int productId, int count);
        bool DeleteItem(float storeId, long customerId, int productId);
        Models.Order.CachedOrderInfo CreateRequest(float storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime);

        Models.Order.CachedOrderInfo GetRequest(float storeId, long customerId);


    }
    public class CachedOrderService : Base.ServiceBase,ICachedOrderService
    {
        public CachedOrderService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public int AddItem(float storeId,long customerId,long addressId,TimeSpan startTime,TimeSpan endTime,int productId,float unitPrice,int count,string name)
        {
            try
            {
                var request = CreateRequest(storeId, customerId, addressId, startTime, endTime);

                int price = Convert.ToInt32(unitPrice, CultureInfo.InvariantCulture);
                int taxPrice = price * 10 / 100;

                var sItem = request.Items?.FirstOrDefault(p => p.ProductId == productId);
                if (sItem != null)
                {
                    sItem.Quantity += count;
                    sItem.UnitPrice += price;
                    sItem.TaxPrice = sItem.UnitPrice * 10 / 100;
                }
                else
                {
                    if(request.Items==null)
                    {
                        request.Items = new List<Models.Order.CachedOrderItem>();
                    }

                    Models.Order.CachedOrderItem item = new Models.Order.CachedOrderItem()
                    {
                        ProductId = productId,
                        Quantity = count,
                        Status = 1,
                        UnitPrice = price,
                        TaxPrice = taxPrice,
                        DiscountPrice = 0,
                        Description = "",
                        ProductName=name
                    };

                    request.Items.Add(item);
                }

                UdpateRequestInfo(request);
                var countResult = request.Items.Select(p => p.Quantity).Sum();
                return countResult;
            }
            catch
            {
                return 0;
            }
        }
        public bool UpdateItem(float storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime, int productId,int count)
        {
            try
            {
                var request = CreateRequest(storeId, customerId, addressId, startTime, endTime);

                var item = request.Items.FirstOrDefault(p => p.ProductId == productId);
                if (item != null)
                {
                    item.Quantity = count;

                    UdpateRequestInfo(request);
                }

                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool DeleteItem(float storeId, long customerId, int productId)
        {
            try
            {
                var request = GetRequest(storeId, customerId);
                if (request == null)
                    return false;

                var item = request.Items.FirstOrDefault(p => p.ProductId == productId);
                if(item!=null)
                {
                    request.Items.Remove(item);
                    UdpateRequestInfo(request);
                }


                return true;
            }
            catch 
            {
                return false;
            }
        }
        public Models.Order.CachedOrderInfo CreateRequest(float storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime)
        {
            DateTime dt = DateTime.Now;

            Models.Order.CachedOrderInfo request = new Models.Order.CachedOrderInfo()
            {
                AddressID = addressId,
                CustomerId = customerId,
                StoreID = storeId,
                StartTime = startTime,
                EndTime = endTime,
                OrderDate = dt,
                OrderTime = dt.TimeOfDay,
                OrderCode =Convert.ToInt32( BehsamFramework.Utility.GenerateUniqueId.GenerateGuid())
            };
            
            string key ="R->"+customerId.ToString()+"->" + storeId.ToString();

            request = CacheService.GetOrSet(
                request,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(20),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove,
                TokenCachClass.CachedOrderToken);

            return request;
        }
        public Models.Order.CachedOrderInfo GetRequest(float storeId, long customerId)
        {
            string key = "R->" + customerId.ToString() + "->" + storeId.ToString();

            try
            {
                var request = CacheService.Get<Models.Order.CachedOrderInfo>(key);
                return request;
            }
            catch
            {
                return new Models.Order.CachedOrderInfo();
            }

            
        }
        private void UdpateRequestInfo(Models.Order.CachedOrderInfo request)
        {
            
            var items=request.Items.Where(p => p.Status == 1);

            int total = items.Select(p => p.Quantity * p.UnitPrice).Sum();
            request.DiscountPrice = items.Select(p=> p.DiscountPrice ).Sum();
            request.TaxPrice = items.Select(p => p.Quantity * p.TaxPrice).Sum();
            request.TotalPrice = total;
            request.ShippingPrice = 10;
            request.FinalPrice = request.TotalPrice+ request.TaxPrice + request.ShippingPrice- request.DiscountPrice;

            string key = "R->" + request.CustomerId.ToString() + "->" + request.StoreID.ToString();

            request = CacheService.RemoveAndSet(
                request,
                key,
                TimeSpan.FromMinutes(20),
                TimeSpan.FromMinutes(20),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.NeverRemove,
                TokenCachClass.CachedOrderToken);

        }

        

    }
}
