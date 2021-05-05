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
using BehsamFramework.Util;

namespace WebSites.Panles.Areas.Stores.Controllers
{
    public class ReportsController : Base.BaseController
    {
        private Services.IReportFacad ReportsService { get; }

        public ReportsController(
            Services.IReportFacad reportsService,
            ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            ReportsService = reportsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //---------------------------------------------------
        //---------------------------------------------------

        public IActionResult GetSummeryOrderStatusByDate(string startDate = "", string endDate = "")
        {
            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                ViewBag.StoreId = sId;
            }
            else
            {
                return Redirect("/Stores/Home/AccessDenied");
            }

            ViewBag.StartDate = !string.IsNullOrEmpty(startDate) ? startDate : DateTime.Now.ToPersianDate();
            ViewBag.EndDate = !string.IsNullOrEmpty(endDate) ? endDate : DateTime.Now.ToPersianDate();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetSummeryOrderStatusByDatePost(string storeId, string startDate, string endDate)
        {

            DateTime stDate = startDate.ToDateTime();
            DateTime enDate = endDate.ToDateTime();


            float sId = 0.0f;

            var style = NumberStyles.AllowDecimalPoint;
            var culture = CultureInfo.InvariantCulture;
            bool i = float.TryParse(storeId, style, CultureInfo.InvariantCulture, out sId);

            var result = await ReportsService.ReportsService.GetSummeryOrderStatusByDate(sId, stDate, enDate);

            if (!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetSummeryOrderStatusByDate>();
            }

            return View("GetSummeryOrderStatusByDatePartialView", result.Value);
        }


        public IActionResult GetSummeryOrderStatusDetailsByDate(string storeId = "", string startDate = "", string endDate = "", int status = 0)
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

            var result = await ReportsService.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, stDate, enDate, status);

            if (!result.IsSuccess)
            {
                result.Value = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();
            }

            return View(result.Value);
        }


        //---------------------------------------------------
        //---------------------------------------------------

        public async Task<IActionResult> GetSummeryOrdersByDateAndStore(string storeId = "", string orderDate = "")
        {

            float sId = 0.0f;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo info = CultureInfo.InvariantCulture;

            if (!string.IsNullOrEmpty(storeId))
            {
                float.TryParse(storeId, style, info, out sId);
            }

            //-----------------------------------------------------------
            //-----------------------------------------------------------

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float.TryParse(user.StoreId, style, info, out sId);
            }
            else
            {
                if (sId <= 0)
                {
                    return Redirect("/Stores/Home/AccessDenied");
                }
            }

            //-----------------------------------------------------------
            //-----------------------------------------------------------

            ViewBag.StoreId = sId;
            ViewBag.OrderDate = string.IsNullOrEmpty(orderDate) ? DateTime.Now.ToPersianDate() : orderDate;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetSummeryOrdersByDateAndStorePost(string storeId, string orderDate)
        {

            FluentResult<List<Models.Reports.GetSummeryOrdersByDateAndStore>> model =
                new FluentResult<List<Models.Reports.GetSummeryOrdersByDateAndStore>>();
            //--------------------------------------------
            float sId = 0.0f;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo info = CultureInfo.InvariantCulture;

            if (!string.IsNullOrEmpty(storeId))
            {
                float.TryParse(storeId, style, info, out sId);
            }


            orderDate = string.IsNullOrEmpty(orderDate) ? DateTime.Now.ToPersianDate() : orderDate;
            DateTime orderDT = orderDate.ToDateTime();

            //------------------------------------------------

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {

                float.TryParse(user.StoreId, style, info, out sId);
            }
            else
            {
                if (sId <= 0)
                {
                    return View(model.Value);
                }
            }

            ViewBag.StoreId = sId;
            ViewBag.OrderDate = orderDate;

            model = await ReportsService.ReportsService.GetSummeryOrdersByDateAndStore(sId, orderDT);

            return View(model.Value);
        }


        public async Task<IActionResult> GetDetailsOrdersByDateAndStore(string storeId, string orderDate, string orderTime)
        {

            float sId = 0.0f;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo info = CultureInfo.InvariantCulture;

            if (!string.IsNullOrEmpty(storeId))
            {
                float.TryParse(storeId, style, info, out sId);
            }


            //-----------------------------------------------------------
            //-----------------------------------------------------------

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {

                float.TryParse(user.StoreId, style, info, out sId);


            }
            else
            {
                if (sId <= 0)
                {
                    return Redirect("/Stores/Home/AccessDenied");
                }
            }

            //-----------------------------------------------------------
            //-----------------------------------------------------------

            ViewBag.StoreId = sId.ToString(System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.OrderDate = string.IsNullOrEmpty(orderDate) ? DateTime.Now.ToPersianDate() : orderDate;
            ViewBag.OrderTime = orderTime;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetDetailsOrdersByDateAndStorePost(string storeId, string orderDate, string orderTime)
        {

            FluentResult<List<Models.Reports.GetDetailsOrdersByDateAndStore>> model =
                new FluentResult<List<Models.Reports.GetDetailsOrdersByDateAndStore>>();
            //--------------------------------------------
            float sId = 0.0f;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo info = CultureInfo.InvariantCulture;

            if (!string.IsNullOrEmpty(storeId))
            {
                float.TryParse(storeId, style, info, out sId);
            }


            orderDate = string.IsNullOrEmpty(orderDate) ? DateTime.Now.ToPersianDate() : orderDate;
            DateTime orderDT = orderDate.ToDateTime();

            //------------------------------------------------

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {

                float.TryParse(user.StoreId, style, info, out sId);
            }
            else
            {
                if (sId <= 0)
                {
                    model = new FluentResult<List<Models.Reports.GetDetailsOrdersByDateAndStore>>();
                    return View(model.Value);
                }
            }

            ViewBag.StoreId = sId.ToString(System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.OrderDate = orderDate;
            ViewBag.OrderTime = orderTime;

            model = await ReportsService.ReportsService.GetDetailsOrdersByDateAndStore(sId, orderDT, orderTime);

            return View(model.Value);
        }

        //--------------------------------------------
        //--------------------------------------------

        public IActionResult GetOrderInfoWithItems(long orderCode = 0)
        {
            ViewBag.OrderCode = orderCode;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderInfoWithItemsPost(long orderCode)
        {

            var result = await ReportsService.ReportsService.GetOrderInfoWithItems(orderCode);

            return View(result.Value);
        }

        //---------------------------------------------------
        //---------------------------------------------------
        public IActionResult GetUserActivitySummeryInDateJourChin()
        {
            ViewBag.ReportDate = System.DateTime.Now.ToPersianDate();

            return View();
        }

        public IActionResult GetUserActivitySummeryInDateSafir()
        {
            ViewBag.ReportDate = System.DateTime.Now.ToPersianDate();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserActivitySummeryInDate(string reportDate, string type)
        {
            FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>> model =
                new FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>();


            DateTime rDate = string.IsNullOrEmpty(reportDate) ? DateTime.Now : reportDate.ToDateTime();
            int roleId = 0,userId=0;
            float sId = 0.0f;

            var style = NumberStyles.AllowDecimalPoint;
            var info = CultureInfo.InvariantCulture;
            
            //----------------------------------------------------
            //----------------------------------------------------

            if (type.Trim().ToLower().Equals("jourchin"))
            {
                roleId = 4;
            }
            else if (type.Trim().ToLower().Equals("safir"))
            {
                roleId = 5;
            }

            //------------------------------------------------
            //------------------------------------------------

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {

                float.TryParse(user.StoreId, style, info, out sId);
            }
            else
            {
                    model = new FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>();
                    return View(model.Value);
            }
            //--------------------------------------------

            model = await ReportsService.ReportsService.GetUserActivitySummeryInDate(rDate, sId, userId, roleId);

            return View(model.Value);
        }

        public async Task<IActionResult> GetUserActivityDetailsInDate(int userId,string orderDate="")
        {
            FluentResult<List<Models.Order.CustomerPreOrderUserActive>> model =
                new FluentResult<List<Models.Order.CustomerPreOrderUserActive>>();

            DateTime reportDate = string.IsNullOrEmpty(orderDate) ? DateTime.Now : orderDate.ToDateTime();

            float sId = 0.0f;

            var style = NumberStyles.AllowDecimalPoint;
            var info = CultureInfo.InvariantCulture;

            //----------------------------------------------------
            //----------------------------------------------------
            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null && userId>0)
            {

                float.TryParse(user.StoreId, style, info, out sId);
            }
            else
            {
                model = new FluentResult<List<Models.Order.CustomerPreOrderUserActive>>();
                return View(model.Value);
            }

            //----------------------------------------------------
            //----------------------------------------------------

            model = await ReportsService.ReportsService.GetUserActivityDetailsInDate(reportDate,sId,userId);

            return View(model.Value);
        }
    }
}
