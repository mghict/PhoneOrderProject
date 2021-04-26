using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using System.Globalization;

namespace WebSites.Panles.Areas.Stores.Controllers
{
    public class OrdersController : Base.BaseController
    {
        private Services.IOrderFacad OrderFacad;
        public OrdersController(Services.IOrderFacad orderFacad, ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            OrderFacad = orderFacad;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetNewOrder(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now, DateTime.Now, 0);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null & model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Contains(searchkey) ||
                                               p.OrderCode.Contains(searchkey)).ToList();
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> GetOrderDetails(long orderCode)
        {
            var model = new Models.Reports.GetOrderInfoWithItems();


            var result = await OrderFacad.ReportsService.GetOrderInfoWithItems(orderCode);
            if (result.IsSuccess)
            {
                model = result.Value;
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StoreAccept(long orderCode)
        {

            try
            {
                var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 2, "تایید توسط کاربر فروشگاه");

                return Json(new { IsSuccess = resp.IsSuccess, Message = resp .GetErrors()});
            }
            catch(Exception ex)
            {
                return Json(new {IsSuccess=false,Message=ex.Message });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> StoreCancel(long orderCode,string reason)
        {

            try
            {
                var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 1, "لغو سفارش توسط کاربر فروشگاه"+": "+reason);

                return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}
