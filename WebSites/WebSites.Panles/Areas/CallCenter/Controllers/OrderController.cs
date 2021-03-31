using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using BehsamFramework.Util;
using System.Globalization;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class OrderController : BaseController
    {
        private Services.Customer.IGetCustomerBySearch GetCustomerBySearch;
        private Services.Customer.IGetCustomer GetCustomer;
        private Services.CustomerPhone.IGetCustomerPhone GetCustomerPhone;
        private Services.CustomerAddress.IGetCustomerAddressService GetCustomerAddressService;

        private Services.IOrderFacad OrderFacad;
        public OrderController(
            Services.IOrderFacad orderFacad,
            Services.Customer.IGetCustomerBySearch getCustomerBySearch,
            Services.Customer.IGetCustomer getCustomer,
            Services.CustomerPhone.IGetCustomerPhone getCustomerPhone,
            Services.CustomerAddress.IGetCustomerAddressService getCustomerAddressService,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            OrderFacad = orderFacad;
            GetCustomerBySearch = getCustomerBySearch;
            GetCustomer = getCustomer;
            GetCustomerPhone = getCustomerPhone;
            GetCustomerAddressService = getCustomerAddressService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderRegister()//(Models.Customer.CustomerProfileModel model)
        {
            //return View(model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderRegister(string searchKey="")
        {
            //var model = new Models.Customer.CustomerProfileModel()
            //{
            //    GetCustomerInfo = new Models.Customer.CustomerInfoModel(),
            //    GetCustomerAddresses=new List<Models.CustomerAddress.CustomerAddressModel>(),
            //    GetCustomerPhones=new List<Models.CustomerPhone.CustomerPhoneModel>()
            //};

            Models.Customer.CustomerInfoModel model = new Models.Customer.CustomerInfoModel();

            if (string.IsNullOrEmpty(searchKey.Trim()))
            {
                return PartialView("CustomerProfilePartialView", model);
            }

 
            if (!string.IsNullOrEmpty(searchKey.Trim()))
            {
                var ret =await GetCustomerBySearch.GetCustomerInfoAsync(searchKey.Trim());
                model = ret;
                //var resp = ret.Result;

                //if (resp != null)
                //{
                //var customerPhones = GetCustomerPhone.Execute(ret.Result.Id);
                //var customerAddress = GetCustomerAddressService.ExecuteGetAddresses(ret.Result.Id);


                //customerPhones.Wait();
                //customerAddress.Wait();

                //model.GetCustomerInfo = ret.Result;
                //model.GetCustomerPhones = customerPhones.Result;
                //model.GetCustomerAddresses = customerAddress.Result;
                //    }

            }
            

            return PartialView("CustomerProfilePartialView", model);
        }

        [HttpGet]
        public async Task< IActionResult> GetTimeSheet(long customerId,long address)
        {
            DateTime dt = DateTime.Now;

            var data =await OrderFacad.GetTimeSheetService.ExecuteAsync(dt);
            
            ViewBag.ToDayDescription = dt.GetPersianFullDate();
            ViewBag.CustomerId = customerId;
            ViewBag.AddressId = address;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreOrder(TimeSpan startTime, TimeSpan endTime, long customerId,long address)
        {
            DateTime requestDate = DateTime.Now;

            var data = await OrderFacad.GetStoreOrderService.GetStores(startTime, endTime,requestDate,customerId);
            
            ViewBag.CustomerId = customerId;
            ViewBag.AddressId = address;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;

            return View(data);
        }

        [HttpGet]
        public IActionResult ShowProductList(TimeSpan startTime, TimeSpan endTime, long customerId, long address,string storeId)
        {
            DateTime requestDate = DateTime.Now;

            //var data = await OrderFacad.GetStoreOrderService.GetStores(startTime, endTime, requestDate, customerId);

            ViewBag.CustomerId = customerId;
            ViewBag.AddressId = address;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            ViewBag.StoreId = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", storeId);

            return View();
        }


        [HttpPost]
        public IActionResult GetCategory()
        {
            var model = OrderFacad.GetCategoryByParentService.Execute(0).Result;
            return View(model);
        }

        [HttpPost]
        public IActionResult GetSubCategory(string catId)
        {
            decimal id = catId.ToDecimal();
            id= 1695.199M;

            var model =  OrderFacad.GetCategoryByParentService.Execute(id).Result;
            return View(model);
        }

        [HttpPost]
        public  IActionResult ShowProduct(string catId,string storeId)
        {
            decimal cid= catId.ToDecimal();
            decimal sid = storeId.ToDecimal();

            cid = 1695.199M;
            sid = 323.199M;

            var model = OrderFacad.GetProductByCategoryAndStoreService.Execute(cid, sid).Result;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart( string storeId,long customerId,long addressId,TimeSpan startTime, TimeSpan endTime,int productId,string unitPrice,int count,string productName)
        {
            try
            {
                TimeSpan start = startTime; //Convert.ToDateTime(startTime).TimeOfDay;
                TimeSpan end = endTime; //Convert.ToDateTime(endTime).TimeOfDay;
                float price;
                float.TryParse(unitPrice, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price);

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                var model = OrderFacad.CachedOrderService.AddItem(sid, customerId, addressId, start, end, productId, price, count,productName);
                
                if( model<1)
                {
                    throw new Exception("امکان اضافه کردن وجود ندارد");
                }

                return Json(new { IsSuccess = true, Message ="محصول اضافه شد",Count =model});
            }
            catch(Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeleteFromCart(string storeId, long customerId, int productId)
        {
            try
            {

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                var result = OrderFacad.CachedOrderService.DeleteItem(sid, customerId, productId);

                if ( !result)
                {
                    throw new Exception("امکان انجام عملیات وجود ندارد");
                }

                return Json(new { IsSuccess = true, Message = "محصول حذف شد" });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }


        }

        [HttpPost]
        public IActionResult ShowCart(string storeId, long customerId)
        {
            Models.Order.CachedOrderInfo model = new Models.Order.CachedOrderInfo();
            try
            {
               
                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                model = OrderFacad.CachedOrderService.GetRequest(sid, customerId);
                
                if (model==null || model.CustomerId<1)
                {
                    throw new Exception("سفارش وجود ندارد");
                }
            }
            catch 
            {
                model = new Models.Order.CachedOrderInfo();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ShowCartCount(string storeId, long customerId)
        {
            Models.Order.CachedOrderInfo model = new Models.Order.CachedOrderInfo();
            try
            {

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                model = OrderFacad.CachedOrderService.GetRequest(sid, customerId);

                int c = 0;

                if (model!=null && model.Items!=null && model.Items.Count>0)
                    c = model.Items.Select(p => p.Quantity).Sum();

               return Json(new { Count = c });
            }
            catch 
            {
                return Json(new { Count=0 });
            }

        }

        [HttpGet]
        public IActionResult ShowInvoice(string storeId, long customerId)
        {
            ViewBag.StoreId = storeId;
            ViewBag.CustomerId = customerId;

            Models.Order.CachedOrderInfo model = new Models.Order.CachedOrderInfo();
            try
            {

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                model = OrderFacad.CachedOrderService.GetRequest(sid, customerId);

                if (model == null || model.CustomerId < 1)
                {
                    throw new Exception("سفارش وجود ندارد");
                }
            }
            catch
            {
                model = new Models.Order.CachedOrderInfo();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Invoice(string storeId, long customerId)
        {
            ViewBag.StoreId = storeId;
            ViewBag.CustomerId = customerId;

            return View();
        }

    }
}
