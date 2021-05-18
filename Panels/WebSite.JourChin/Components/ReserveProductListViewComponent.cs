using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.JourChin.Services.Order;

namespace WebSite.JourChin.Components
{
    public class ReserveProductListViewComponent: ViewComponent
    {
        private readonly Services.Order.IOrderService _orderService;

        public ReserveProductListViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long itemId)
        {
            ViewBag.ItemIdOrderReserve = itemId;

            var model = await _orderService.GetItemReserveDetailsAsync(itemId);
            return await Task.FromResult((IViewComponentResult)View("ReserveProductList", model.ValueOrDefault));
        }
    }
}
