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
using Microsoft.AspNetCore.SignalR;
using WebSites.Panles.Hubs;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class OrderController : BaseController
    {
        private Services.Customer.IGetCustomerBySearch GetCustomerBySearch;
        private Services.Customer.IGetCustomer GetCustomer;
        private Services.CustomerPhone.IGetCustomerPhone GetCustomerPhone;
        private Services.CustomerAddress.IGetCustomerAddressService GetCustomerAddressService;
        private Services.Map.NeshanMapService NeshanMapService;

        private Services.IOrderFacad OrderFacad;
        private readonly Services.Notification.INotificationService _notificationService;

        public OrderController(
            Services.Map.NeshanMapService neshanMapService,
            Services.Notification.INotificationService NotificationService,
            Services.IOrderFacad orderFacad,
            Services.Customer.IGetCustomerBySearch getCustomerBySearch,
            Services.Customer.IGetCustomer getCustomer,
            Services.CustomerPhone.IGetCustomerPhone getCustomerPhone,
            Services.CustomerAddress.IGetCustomerAddressService getCustomerAddressService,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            OrderFacad = orderFacad;
            GetCustomerBySearch = getCustomerBySearch;
            GetCustomer = getCustomer;
            GetCustomerPhone = getCustomerPhone;
            GetCustomerAddressService = getCustomerAddressService;
            _notificationService = NotificationService;
            NeshanMapService = neshanMapService;
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
        public async Task<IActionResult> OrderRegister(string searchKey = "")
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
                var ret = await GetCustomerBySearch.GetCustomerInfoAsync(searchKey.Trim());
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
        public async Task<IActionResult> GetTimeSheet(long customerId, long address)
        {
            DateTime dt = DateTime.Now;

            var data = await OrderFacad.GetTimeSheetService.ExecuteAsync(dt);

            ViewBag.ToDayDescription = dt.GetPersianFullDate();
            ViewBag.CustomerId = customerId;
            ViewBag.AddressId = address;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreOrder(TimeSpan startTime, TimeSpan endTime, long customerId, long address)
        {
            DateTime requestDate = DateTime.Now;

            var data = await OrderFacad.GetStoreOrderService.GetStores(startTime, endTime, requestDate, address);

            List<Models.Map.Location> distination = new List<Models.Map.Location>();
            var disItem = data.Select(s => new Models.Map.Location
            {
                X = Convert.ToDecimal(s.sourceLatitude),
                Y = Convert.ToDecimal(s.sourceLongitude)
            }).FirstOrDefault();
            distination.Add(disItem);

            var source = data.Select(s => new Models.Map.Location
            {
                X = Convert.ToDecimal(s.Latitude),
                Y = Convert.ToDecimal(s.Longitude)
            }).ToList();

            var distMatrix = await NeshanMapService.DistanceMatrixApi(source.ToList(), distination);
            if (distMatrix != null && !string.IsNullOrEmpty(distMatrix.Status))
            {
                if (distMatrix.Status.Trim().ToUpper() == "OK")
                {
                    for (int i = 0; i < distMatrix.origin_addresses.Count; i++)
                    {
                        string orgin_add = distMatrix.origin_addresses[i];
                        if (!string.IsNullOrEmpty(orgin_add) && orgin_add.Contains(","))
                        {

                            var existsItem = data[i] as BehsamFramework.Models.StoreOrderModel;

                            if (existsItem != null)
                            {
                                existsItem.TimeDistanceText = distMatrix.rows[i].Elements[0].Duration.Text;
                                existsItem.TimeDistanceValue = distMatrix.rows[i].Elements[0].Duration.Value;

                                existsItem.UnitDistanceText = distMatrix.rows[i].Elements[0].Distance.Text;
                                existsItem.UnitDistanceValue = distMatrix.rows[i].Elements[0].Distance.Value;
                            }
                        }
                    }
                }
            }
            ViewBag.CustomerId = customerId;
            ViewBag.AddressId = address;
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;

            data = data.OrderBy(p => p.UnitDistanceValue).ThenBy(p => p.TimeDistanceValue).ToList();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> ShowProductList(TimeSpan sT, TimeSpan eT, long cId, long add, string sId,int shipp)//,
            //string catId="0", int pageNumber=0,int pageSize=21,string searchKey="")
        {
            DateTime requestDate = DateTime.Now;

            ViewBag.CustomerId = cId;
            ViewBag.AddressId = add;
            ViewBag.StartTime = sT;
            ViewBag.EndTime = eT;
            ViewBag.Shipping = shipp;
            ViewBag.StoreId = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", sId);

            //var model = await ShowProductModel(sId, catId, pageNumber, pageSize, searchKey);

            return View();//model);
        }


        [HttpPost]
        public IActionResult GetCategory()
        {
            var model = OrderFacad.GetCategoryByParentService.Execute(0).Result;

            var item = new BehsamFramework.Models.CategoryShowModel()
            {
                Id=0f,
                CategoryName="همه محصولات",
                ParentId=0,
                Priority=1,
                Status=1
            };

            var exists = model.FirstOrDefault(p => p.Id == 0.0f);
            if (exists == null)
            {
                model.Add(item);
            }
            return View(model.OrderBy(p=>p.Id).ToList());
        }

        [HttpPost]
        public IActionResult GetSubCategory(string catId)
        {
            decimal id = catId.ToDecimal();
            
            if(id<=0)
            {
                return View(new List<BehsamFramework.Models.CategoryShowModel>());
            }

            var model = OrderFacad.GetCategoryByParentService.Execute(id).Result;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ShowProduct(string storeId, string catId, int pageNumber = 0, int pageSize = 21,string searchKey="")
        {
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchKey = searchKey;

            var model = await ShowProductModel(storeId, catId, pageNumber, pageSize, searchKey);

            return View(model);
        }


        [HttpPost]
        public IActionResult AddToCart(string storeId, long customerId, long addressId, TimeSpan startTime, TimeSpan endTime, int productId, string unitPrice, int count, string productName,int tax,int shipping)
        {
            try
            {
                TimeSpan start = startTime; //Convert.ToDateTime(startTime).TimeOfDay;
                TimeSpan end = endTime; //Convert.ToDateTime(endTime).TimeOfDay;
                float price;
                float.TryParse(unitPrice, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price);

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                var model = OrderFacad.CachedOrderService.AddItem(sid, customerId, addressId, start, end, productId, price, count, productName,shipping,tax);

                if (model < 1)
                {
                    throw new Exception("امکان اضافه کردن وجود ندارد");
                }

                return Json(new { IsSuccess = true, Message = "محصول اضافه شد", Count = model });
            }
            catch (Exception ex)
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

                if (!result)
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

                if (model != null && model.Items != null && model.Items.Count > 0)
                    c = model.Items.Select(p => p.Quantity).Sum();

                return Json(new { Count = c });
            }
            catch
            {
                return Json(new { Count = 0 });
            }

        }

        [HttpGet]
        public IActionResult Invoice(string storeId, long customerId)
        {
            ViewBag.StoreId = storeId;
            ViewBag.CustomerId = customerId;

            return View();
        }

        [HttpPost]
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

        [HttpPost]
        public IActionResult RegisterOrderFinal(string storeId, long customerId)
        {
            ViewBag.StoreId = storeId;
            ViewBag.CustomerId = customerId;

            Models.Order.CachedOrderInfo model = new Models.Order.CachedOrderInfo();
            FluentResult result = new FluentResult();
            try
            {

                float sid;
                float.TryParse(storeId, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out sid);

                model = OrderFacad.CachedOrderService.GetRequest(sid, customerId);

                if (model == null || model.CustomerId < 1)
                {
                    throw new Exception("سفارش وجود ندارد");
                }

                result = OrderFacad.CreateOrderService.Execute(model).Result;

                if (result.IsSuccess)
                {
                    string key = "R->" + model.CustomerId.ToString() + "->" + model.StoreID.ToString("#.##", CultureInfo.InvariantCulture);

                    CacheService.ClearCache(key);



                    Models.NotificationMessage message = new Models.NotificationMessage()
                    {
                        messageBody = $"سفارش به شماره {model.OrderCode} در شعبه {model.StoreID} به ثبت رسید",
                        messageHead = "ثبت سفارش",
                        messageType = 1,
                        CreateDate = DateTime.Now,
                        status = true,
                        storeId = model.StoreID,
                        userId = 0
                    };

                    _notificationService.CreateGeneralNotification(message);

                    //return View();
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return Json(new { IsSuccess = result.IsSuccess, Message = result.GetErrors(), Code = model.OrderCode });
        }

        private async Task<BehsamFramework.Models.ProductsModel> ShowProductModel(string storeId, string catId, int pageNumber = 0, int pageSize = 21, string searchKey = "")
        {
            decimal cid = 0M;
            decimal sid = 0M;

            CultureInfo info = CultureInfo.InvariantCulture;
            NumberStyles style = NumberStyles.AllowDecimalPoint;

            decimal.TryParse(storeId, style, info, out sid);
            decimal.TryParse(catId, style, info, out cid);


            var model = await OrderFacad.ProductsService.Execute(sid, cid, pageNumber, pageSize, searchKey);

            return model;
        }

    }
}
