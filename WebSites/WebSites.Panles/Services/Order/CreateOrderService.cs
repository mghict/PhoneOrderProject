using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Order
{
    public interface ICreateOrderService
    {
        Task<FluentResult> Execute(Models.Order.CachedOrderInfo model);
    }
    public class CreateOrderService : Base.ServiceBase, ICreateOrderService
    {
        public CreateOrderService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<FluentResult> Execute(Models.Order.CachedOrderInfo model)
        {
            FluentResult result = new FluentResult();
            try
            {
                Models.Order.OrderInfo info = new Models.Order.OrderInfo()
                {
                    AddressId = model.AddressID,
                    CustomerId = model.CustomerId,
                    DiscountPrice = model.DiscountPrice,
                    FinalPrice = model.FinalPrice,
                    OrderCode = model.OrderCode,
                    OrderDate = model.OrderDate,
                    OrderState = model.OrderState,
                    OrderTime = model.OrderTime,
                    PaymentType = model.PaymentType,
                    ShippingPrice = model.ShippingPrice,
                    StoreId = model.StoreID,
                    TaxPrice = model.TaxPrice,
                    TotalPrice = model.TotalPrice,
                    Detail = new Models.Order.OrderInfoDetails()
                    {
                        EndTime = model.EndTime,
                        StartTime = model.StartTime,
                        UserId = 1,
                        UserStoreId = 1
                    },
                    Items = model.Items.Select(p => new Models.Order.OrderItems
                    {
                        Description = p.Description,
                        DiscountPrice = p.DiscountPrice,
                        ProductId = p.ProductId,
                        Quantity = p.Quantity,
                        Status = p.Status,
                        TaxPrice = p.TaxPrice,
                        UnitPrice = p.UnitPrice
                    }).ToList()
                };
                var command = new
                {
                    OrderInfo = info
                };

                result = await ServiceCaller.PostDataWithoutValue("Order/Order/Create", command);
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }

    }
}
