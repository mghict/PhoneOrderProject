using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Services;
using BehsamFramework.Util;
using System.Globalization;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using WebSites.Panles.Helper;
using AutoMapper;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class ReportController : BaseController
    {
        private readonly Services.IOrderFacad _OrderFacad;

        public ReportController(Services.IOrderFacad OrderFacad, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _OrderFacad = OrderFacad;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSummeryOrderByDate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetSummeryOrderByDate(string startDate, string endDate)
        {

            DateTime stDate= startDate.ToDateTime();
            DateTime enDate = endDate.ToDateTime();

            var result =await _OrderFacad.ReportsService.GetSummeryOrderByDate(stDate, enDate);

            if(!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetSummeryOrderByDate>();
            }

            return PartialView("GetSummeryOrderByDatePartialView", result.Value);
        }

        public IActionResult GetSummeryOrderStatusByDate(string storeId="", string startDate="", string endDate="")
        {
            if(!string.IsNullOrEmpty(storeId))
            {
                ViewBag.StoreId = storeId;
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                ViewBag.StartDate = startDate;
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                ViewBag.EndDate = endDate;
            }

            return View();
        }

        [HttpPost]
        public async Task< IActionResult> GetSummeryOrderStatusByDatePost(string storeId,string startDate, string endDate)
        {

            DateTime stDate = startDate.ToDateTime();
            DateTime enDate = endDate.ToDateTime();
            
            
            float sId = 0.0f;

            var style = NumberStyles.AllowDecimalPoint;
            var culture = CultureInfo.InvariantCulture;
            bool i=float.TryParse(storeId,style, CultureInfo.InvariantCulture,out sId);

            var result = await _OrderFacad.ReportsService.GetSummeryOrderStatusByDate(sId,stDate, enDate);

            if (!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetSummeryOrderStatusByDate>();
            }

            return PartialView("GetSummeryOrderStatusByDatePartialView", result.Value);
        }

        public IActionResult GetSummeryOrderStatusDetailsByDate(string storeId = "", string startDate = "", string endDate = "",int status=0)
        {
            if (!string.IsNullOrEmpty(storeId))
            {
                ViewBag.StoreId = storeId;
            }

            if (!string.IsNullOrEmpty(startDate))
            {
                ViewBag.StartDate = startDate;
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                ViewBag.EndDate = endDate;
            }

            //if (status>0)
            //{
                ViewBag.Status = status;
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetSummeryOrderStatusDetailsByDatePost(string storeId = "", string startDate = "", string endDate = "", int status = 0)
        {
            DateTime stDate = startDate.ToDateTime();
            DateTime enDate = endDate.ToDateTime();


            float sId = 0.0f;

            var style = NumberStyles.AllowDecimalPoint;
            var culture = CultureInfo.InvariantCulture;
            bool i = float.TryParse(storeId, style, CultureInfo.InvariantCulture, out sId);

            var result = await _OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, stDate, enDate,status);

            if (!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();
            }

            return PartialView("GetSummeryOrderStatusDetailsByDatePartialView", result.Value);
        }

        public IActionResult GetOrderDetailsByUserId()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderDetailsByUserIdPost( string startDate = "", string endDate = "")
        {
            DateTime stDate = startDate.ToDateTime();
            DateTime enDate = endDate.ToDateTime();

            var user = HttpContext.Session.Get<Models.UserModel>("User");
            
            if(user==null)
            {
                var model= new List<Models.Reports.GetOrderDetailsByUserId>();
                return PartialView("GetOrderDetailsByUserIdPartialView", model);
            }

            var result = await _OrderFacad.ReportsService.GetOrderDetailsByUserId(stDate, enDate, 0.0f, user.UserId);

            if (!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetOrderDetailsByUserId>();
            }

            return PartialView("GetOrderDetailsByUserIdPartialView", result.Value);
        }

        public IActionResult GetOrderInfoWithItems(long orderCode=0)
        {
            ViewBag.OrderCode = orderCode;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderInfoWithItemsPost(long orderCode)
        {

            var result = await _OrderFacad.ReportsService.GetOrderInfoWithItems(orderCode);

            return PartialView("GetOrderInfoWithItemsPartialView", result.Value);
        }
    }
}
