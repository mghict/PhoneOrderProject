using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
//using Aspose.BarCode.BarCodeRecognition;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.JourChin.Helper;
using System.Drawing;

namespace WebSite.JourChin.Controllers
{
    public class OrdersController : Base.BaseController
    {
        private readonly Services.User.IUserActivityService _userActivityService;
        private readonly Services.Order.IOrderService _orderService;

        public OrdersController(
            Services.Order.IOrderService OrderService,
            Services.User.IUserActivityService UserActivityService,
            ServiceCaller serviceCaller, ICachedMemoryService _cacheService, IMapper mapper) : base(serviceCaller, _cacheService, mapper)
        {
            _userActivityService = UserActivityService;
            _orderService = OrderService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() =>
            {
                return View();
            });

        }



        //--------------------------------------------
        // سفارشات جاری
        //--------------------------------------------
        public async Task<IActionResult> CurrentOrder()
        {
            List<Models.User.OrderUserActivity> model = new List<Models.User.OrderUserActivity>();

            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                model = await _userActivityService.GetOrderUserActivityByStatusAsync(3, 3);
            }

            return await Task.Run(() =>
            {
                return View(model);
            });

        }


        [HttpPost]
        public async Task<IActionResult> AcceptItem(long orderId,long itemId)
        {
            
            try
            {
                var result = await _orderService.AcceptUserForOrderItems(orderId, itemId);
                return Json(new { IsSuccess = result.IsSuccess, Message = result.Errors.Select(s=>s.Message).ToList().ListToString() });
            }
            catch(Exception ex)
            {
                return Json(new {IsSuccess=false,Message=ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> FirstStateItem(long orderId, long itemId)
        {

            try
            {
                var result = await _orderService.FirstStateUserForOrderItems(orderId, itemId);
                return Json(new { IsSuccess = result.IsSuccess, Message = result.Errors.Select(s => s.Message).ToList().ListToString() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ComplateOrder(long orderCode)
        {

            try
            {
                var result = await _orderService.ChangeOrderStatus(orderCode,5,"تایید تکمیل سفارش توسط کاربر");
                return Json(new { IsSuccess = result.IsSuccess, Message = result.Errors.Select(s => s.Message).ToList().ListToString() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        
        //--------------------------------------------
        // اعلام جایگزینی کالا
        //--------------------------------------------

        [HttpGet]
        public async Task<IActionResult> RejectItem(long orderId, long itemId, long orderCode)
        {
            FluentResults.Result<Models.Order.GetOrderInfoWithItems> model =
                new FluentResults.Result<Models.Order.GetOrderInfoWithItems>();

            model = await _orderService.GetOrderInfoWithItems(orderCode);

            if (model.IsFailed)
            {
                model = new FluentResults.Result<Models.Order.GetOrderInfoWithItems>();
            }

            var item = model.Value?.OrderItems.FirstOrDefault(p => p.OrderId == orderId && p.Id == itemId);
            ViewBag.OrderCode = orderCode;

            ViewBag.ItemIdOrderReserve = item.Id;

            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> RejectListItem(long itemId)
        {
            ViewBag.ItemIdOrderReserve = itemId;

            var model =await _orderService.GetItemReserveDetailsAsync(itemId);

            return View(model.Value);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProducts(string productName,string brandName,bool sameCategory)
        {
            

            return View();
        }

        //--------------------------------------------
        // جزئیات سفارش
        //--------------------------------------------
        public async Task<IActionResult> OrderItems(long orderCode)
        {
            FluentResults.Result<Models.Order.GetOrderInfoWithItems> model =
                new FluentResults.Result<Models.Order.GetOrderInfoWithItems>();

            model = await _orderService.GetOrderInfoWithItems(orderCode);

            if (model.IsFailed)
            {
                model = new FluentResults.Result<Models.Order.GetOrderInfoWithItems>();
            }
            return View(model.ValueOrDefault);
        }

        //--------------------------------------------
        // اطلاعات تکمیل شده
        //--------------------------------------------
        public async Task<IActionResult> ComplateOrders()
        {
            List<Models.User.OrderUserActivity> model = new List<Models.User.OrderUserActivity>();

            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                model = await _userActivityService.GetOrderUserActivityByStatusAsync(3, 5);
            }

            return await Task.Run(() =>
            {
                return View(model);
            });

        }

        [HttpPost]
        public async Task<IActionResult> CurrentOrderChange(long orderCode)
        {

            try
            {
                var result = await _orderService.ChangeOrderStatus(orderCode, 3, "برگشت به وضعیت درحال پردازش توسط جورچین توسط کاربر");
                return Json(new { IsSuccess = result.IsSuccess, Message = result.Errors.Select(s => s.Message).ToList().ListToString() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }

        //--------------------------------------------
        //--------------------------------------------
        public async Task<IActionResult> ScanItem()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting Filename  
                        var fileName = file.FileName;
                        // Unique filename "Guid"  
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        // Getting Extension  
                        var fileExtension = Path.GetExtension(fileName);
                        // Concating filename + fileExtension (unique filename)  
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        //  Generating Path to store photo   
                        var filepath = Path.Combine("D:\\", "CameraPhotos") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                        {
                            // Storing Image in Folder  
                            StoreInFolder(file, filepath);
                        }


                        System.Drawing.Image img = System.Drawing.Image.FromFile(filepath);
                        StringBuilder sbCodeType = new StringBuilder();
                        StringBuilder sbCodeText = new StringBuilder();

                        BarcodeReader reader = new BarcodeReader();
                        reader.AutoRotate = true;
                        
                        var result = reader.Decode((Bitmap)img);
                        if(result!=null)
                        {
                            sbCodeText.Append(result.ToString());
                        }

                        reader = null;

                        sbCodeText.ToString();
                        //using (BarCodeReader reader = new BarCodeReader(filepath, DecodeType.EAN13))
                        //{
                        //    var items = reader.ReadBarCodes();
                        //    foreach (BarCodeResult result in items)
                        //    {
                        //        // Read symbology type and code text
                        //        sbCodeType.Append(result.CodeType);
                        //        sbCodeText.Append( result.CodeText);
                        //    }

                        //}


                        var imageBytes = System.IO.File.ReadAllBytes(filepath);
                        if (imageBytes != null)
                        {
                            // Storing Image in Folder  
                            //StoreInDatabase(imageBytes);
                        }

                    }
                }
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

    }
}

