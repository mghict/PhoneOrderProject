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
using WebSites.Panles.Models.Authorize;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSites.Panles.Areas.Stores.Controllers
{
    public class OrdersController : Base.BaseController
    {
        private Services.IOrderFacad OrderFacad;
        private Services.IUserFacad UserFacad;
        public OrdersController(Services.IUserFacad userFacad,Services.IOrderFacad orderFacad, ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            OrderFacad = orderFacad;
            UserFacad = userFacad;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //--------------------------------------------------------
        // New Order for Store
        //--------------------------------------------------------
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

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 0);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StoreAccept(long orderCode)
        {

            try
            {
                var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 2, "تایید توسط کاربر فروشگاه");

                return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> StoreCancel(long orderCode, string reason)
        {

            try
            {
                var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 1, "لغو سفارش توسط کاربر فروشگاه" + ": " + reason);

                return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
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

        //-------------------------------------------------------
        // General Methods 
        //-------------------------------------------------------

        [NonAction]
        private async Task<List<UserInfo>> GetUsers(int type)
        {
            var model = new List<UserInfo>();

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var resp = await UserFacad.UserActivityService.GetAllUserActiveCurrentDateAsync(type, sId, "", 0, 10000, 2);
                model = resp.Users;
            }

            return model;
        }

        [HttpPost]
        public  IActionResult GetUserActivity(int userId)
        {
            var model = OrderFacad.OrderUserActive.GetSummeryByUserId(userId).Result;

            return View(model);
        }


        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        // تخصیص جورچین
        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        public async Task<IActionResult> GetAcceptOrder(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 2);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }


            var userList = (await GetUsers(4)).Select(s => new {
                Name = string.Concat(s.Name, "-", s.UserName),
                Id = s.Id
            }).ToList();

            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        public async Task<IActionResult> GetAcceptOrderDetails(long orderCode)
        {
            var model = new Models.Reports.GetOrderInfoWithItems();


            var result = await OrderFacad.ReportsService.GetOrderInfoWithItems(orderCode);
            if (result.IsSuccess)
            {
                model = result.Value;
            }

            var userList = (await GetUsers(4)).Select(s=>new { 
                Name=string.Concat(s.Name,"-",s.UserName),
                Id=s.Id
            }).ToList();

            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineJourChin(long orderCode,int userId)
        {
            try
            {
                Models.Order.CustomerPreOrderUserActive model = new Models.Order.CustomerPreOrderUserActive()
                {
                    CreateDate = DateTime.Now,
                    OrderCode = orderCode,
                    Status = 3,
                    StatusDescription = "تخصیص به جورچین",
                    UserId = userId
                };

                var respChange = await OrderFacad.OrderUserActive.Create(model);
                if (respChange != null && respChange.IsSuccess && respChange.Value > 0)
                {
                    model.Id = respChange.Value;

                    var respOrderChange = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 3, "تخصیص به جورچین");

                    if (respOrderChange != null && respOrderChange.IsSuccess)
                    {
                        return Json(new { IsSuccess = true, Message = "" });
                    }
                    else
                    {
                        await OrderFacad.OrderUserActive.Delete(model);
                        return Json(new { IsSuccess = false, Message = respOrderChange.GetErrors() });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = respChange.GetErrors() });
                }
            }
            catch(Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }

            //return View(model);
        }

        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        // تایید تکمیل سفارش توسط جورچین
        //--------------------------------------------------------
        // الان وضعیت 3 را می آورد درصورت راه اندازی پنل جورچین باید 5 را بیاورد
        //--------------------------------------------------------
        //--------------------------------------------------------

        public async Task<IActionResult> GetAcceptJourChinOrder(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 5);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }


            //var userList = (await GetUsers(4)).Select(s => new {
            //    Name = string.Concat(s.Name, "-", s.UserName),
            //    Id = s.Id
            //}).ToList();

            //ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        public async Task<IActionResult> GetAcceptJourChinOrderDetails(long orderCode)
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
        public async Task<IActionResult> StoreAcceptJourChin(long orderCode)
        {

            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
                if (user != null)
                {
                    var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 11, "جهت ارسال به صندوق فروشگاه");
                    if (resp.IsSuccess)
                    {
                        
                        Models.Order.CustomerPreOrderUserActive model = new Models.Order.CustomerPreOrderUserActive()
                        {
                            CreateDate = DateTime.Now,
                            OrderCode = orderCode,
                            Status = 11,
                            StatusDescription = "تایید تکمیل جورچین و ارسال به صندوق",
                            UserId = user.UserId
                        };

                        var respUserAct = await OrderFacad.OrderUserActive.Update(model);

                    }

                    return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "اطلاعات کاربر یافت نشد" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        // نمایش فاکتور برای استعلام
        //--------------------------------------------------------
        //--------------------------------------------------------
        public async Task<IActionResult> GetOrderForBill(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 11);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }


            return View(model);
        }


        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        // تخصیص سفیر
        //--------------------------------------------------------
        //--------------------------------------------------------
        public async Task<IActionResult> GetOrderForDefineSafir(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 12);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }


            var userList = (await GetUsers(5)).Select(s => new {
                Name = string.Concat(s.Name, "-", s.UserName),
                Id = s.Id
            }).ToList();

            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        public async Task<IActionResult> GetOrderForDefineSafirDetails(long orderCode)
        {
            var model = new Models.Reports.GetOrderInfoWithItems();


            var result = await OrderFacad.ReportsService.GetOrderInfoWithItems(orderCode);
            if (result.IsSuccess)
            {
                model = result.Value;
            }

            var userList = (await GetUsers(5)).Select(s => new {
                Name = string.Concat(s.Name, "-", s.UserName),
                Id = s.Id
            }).ToList();

            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DefineSafir(long orderCode, int userId)
        {
            try
            {
                Models.Order.CustomerPreOrderUserActive model = new Models.Order.CustomerPreOrderUserActive()
                {
                    CreateDate = DateTime.Now,
                    OrderCode = orderCode,
                    Status = 21,
                    StatusDescription = "تخصیص به سفیر",
                    UserId = userId
                };

                var respChange = await OrderFacad.OrderUserActive.Create(model);
                if (respChange != null && respChange.IsSuccess && respChange.Value > 0)
                {
                    model.Id = respChange.Value;

                    var respOrderChange = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 21, "تخصیص به سفیر");

                    if (respOrderChange != null && respOrderChange.IsSuccess)
                    {
                        return Json(new { IsSuccess = true, Message = "" });
                    }
                    else
                    {
                        await OrderFacad.OrderUserActive.Delete(model);
                        return Json(new { IsSuccess = false, Message = respOrderChange.GetErrors() });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = respChange.GetErrors() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }

            //return View(model);
        }


        //--------------------------------------------------------
        //--------------------------------------------------------
        //--------------------------------------------------------
        // تحویل کالا به سفیر
        //--------------------------------------------------------
        //--------------------------------------------------------
        public async Task<IActionResult> GetOrderToSafir(string searchkey = "")
        {
            var model = new List<Models.Reports.GetSummeryOrderStatusDetailsByDate>();


            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                var result = await OrderFacad.ReportsService.GetSummeryOrderStatusDetailsByDate(sId, DateTime.Now.AddDays(-10), DateTime.Now, 21);
                if (result.IsSuccess)
                {
                    model = result.Value;

                    if (!string.IsNullOrEmpty(searchkey) && model != null && model.Count > 0)
                    {
                        model = model.Where(p => p.CustomerName.Trim().Contains(searchkey) ||
                                                 p.OrderCode.Trim().Contains(searchkey) ||
                                                 p.UserDescription.Trim().Contains(searchkey) ||
                                                 p.OrderTime.Trim().Contains(searchkey)).ToList();
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> GetOrderToSafirDetails(long orderCode)
        {
            var model = new Models.Reports.GetOrderInfoWithItems();


            var result = await OrderFacad.ReportsService.GetOrderInfoWithItems(orderCode);
            if (result.IsSuccess)
            {
                model = result.Value;
            }

            var userList = (await GetUsers(5)).Select(s => new {
                Name = string.Concat(s.Name, "-", s.UserName),
                Id = s.Id
            }).ToList();

            ViewBag.UserList = new SelectList(userList, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StoreAcceptToSafir(long orderCode)
        {

            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
                if (user != null)
                {
                    var resp = await OrderFacad.OrderService.ChangeOrderStatus(orderCode, 22, "تحویل سفارش فروشگاه به سفیر");
                    if (resp.IsSuccess)
                    {

                        Models.Order.CustomerPreOrderUserActive model = new Models.Order.CustomerPreOrderUserActive()
                        {
                            CreateDate = DateTime.Now,
                            OrderCode = orderCode,
                            Status = 22,
                            StatusDescription = "تایید تحویل سفارش به سفیر",
                            UserId = user.UserId
                        };

                        var respUserAct = await OrderFacad.OrderUserActive.Update(model);

                    }

                    return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "اطلاعات کاربر یافت نشد" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}
