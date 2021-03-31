using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using WebSites.Panles.Models.CustomerPhone;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class CustomerPhoneController : BaseController
    {
        private Services.CustomerPhone.IGetCustomerPhone GetCustomerPhone;
        private Services.CustomerPhone.IGetPhoneByIdService GetPhoneByIdService;
        public CustomerPhoneController(Services.CustomerPhone.IGetPhoneByIdService getPhoneByIdService,Services.CustomerPhone.IGetCustomerPhone getCustomerPhone,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            GetCustomerPhone = getCustomerPhone;
            GetPhoneByIdService = getPhoneByIdService;
        }

        public async Task<IActionResult> Index(long customerId)
        {
            //var model = await GetCustomerPhone.Execute(customerId);
            //return View(model);
            ViewBag.CustomerId = customerId;
            var model = await GetCustomerPhone.Execute(customerId);
            return View(model);
        }

        public async Task<IActionResult> PartialGetAllView(long customerId)
        {
            var model = await GetCustomerPhone.Execute(customerId);
            return PartialView("CustomerPhonePartialView", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long phoneId)
        {

            try
            {
                var model = new
                {
                    Id = phoneId
                };
                var ret = await ServiceCaller.PostDataWithoutValue("phone/remove", model);

                if (ret != null)
                {
                    if (ret.IsSuccess)
                    {
                        var task=CacheService.ClearTokenAsync(TokenCachClass.CustomerPhonesAdd);
                        task.Wait();
                    }
                    return Json(new { IsSuccess = ret.IsSuccess, Errors = ret.GetErrors()});
                }
                else
                {
                    throw new Exception("خطا در عملیات");
                }

            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false, Errors = e.Message });
            }

        }

        [HttpGet]
        public async Task<IActionResult> Insert(long customerId)
        {

            await FillViewBag();

            var model = new Models.CustomerPhone.CustomerPhoneRegisterModel()
            {
                CustomerId = customerId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CustomerPhoneRegisterModel model, string returnUrl)
        {
            var fill = FillViewBag();
            try
            {
                model.Status = 1;
                

                if (ModelState.IsValid)
                {

                    var ret = await ServiceCaller.PostDataWithoutValue("phone/Create", model);

                    if (ret != null)
                    {
                        
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        ViewBag.ReturnUrl =null;
                        fill.Dispose();
                        var task= CacheService.ClearTokenAsync(TokenCachClass.CustomerPhonesAdd);
                        task.Wait();
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    fill.Wait();
                    ViewBag.ReturnUrl = returnUrl;
                    
                    return View("Insert", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                fill.Wait();
                ViewBag.ReturnUrl = returnUrl;

                return View("Insert", model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(long phoneId)
        {
            await FillViewBag();

            var model = await GetPhoneByIdService.ExecuteUpdateModel(phoneId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerPhoneRegisterModel model, string returnUrl)
        {
            var fill = FillViewBag();

            try
            {
                
                if (ModelState.IsValid)
                {

                    var ret = await ServiceCaller.PostDataWithoutValue("phone/update", model);

                    if (ret != null)
                    {

                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }
                        ViewBag.ReturnUrl = null;
                        fill.Dispose();
                        var task=CacheService.ClearTokenAsync(TokenCachClass.CustomerPhonesAdd);
                        task.Wait();
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    fill.Wait();
                    ViewBag.ReturnUrl = returnUrl;
                    return View("Update", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                fill.Wait();
                ViewBag.ReturnUrl = returnUrl;
                return View("Update", model);
            }


        }


        [HttpGet]
        public async Task<IActionResult> ShowPhone(long phoneId)
        {
            var phone = await GetPhone(phoneId);
            var model = phone.Value;
            return View(model);
        }


        //-----------------------------------------------------
        //-----------------------------------------------------

        private async Task FillViewBag()
        {
            await Task.Run(() =>
            {
                var sts = StaticValues.GetStatuses;
                var phoneSts = sts.Where(p => p.Subject.Equals("CustomerPhoneStatus"));
                ViewBag.PhoneStatus = new SelectList(phoneSts, "StatusId", "Name");

                var phoneType = sts.Where(p => p.Subject.Equals("CustomerPhoneType"));
                ViewBag.PhoneType = new SelectList(phoneType, "StatusId", "Name");

                ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();

            });
            
        }
        private async Task<List<BehsamFramework.Models.CustomerPhoneModel>> GetCustomerPhones(long customerId)
        {
            var Command = new
            {
                Id = customerId
            };

            FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>> model =
                new FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<List<BehsamFramework.Models.CustomerPhoneModel>>("Phone/GetCustomerPhones", Command);

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<BehsamFramework.Models.CustomerPhoneModel>>();
                model.WithError(ex.Message);
            }

            return model.Value;
        }

        private async Task<List<BehsamFramework.Models.CustomerPhoneModel>> GetPhones(long customerId)
        {
            List<BehsamFramework.Models.CustomerPhoneModel> ret =
                new List<BehsamFramework.Models.CustomerPhoneModel>();

            string cashedKey = "CustomerPhone" + customerId;

            try
            {
                ret = await CacheService.GetOrSetAsync
                    (ret,
                    customerId,
                    cashedKey,
                    TimeSpan.FromMinutes(10),
                    TimeSpan.FromMinutes(5),
                    CacheItemPriority.Low,
                    TokenCachClass.CustomerAddressesAdd,
                    GetCustomerPhones);

            }
            catch (Exception ex)
            {
                ret = new List<BehsamFramework.Models.CustomerPhoneModel>();
            }

            return ret;

        }

        [HttpGet]
        private async Task<FluentResult<BehsamFramework.Models.CustomerPhoneModel>> GetPhone(long phoneId)
        {

            var Command = new
            {
                Id = phoneId
            };

            FluentResult<BehsamFramework.Models.CustomerPhoneModel> model =
                new FluentResult<BehsamFramework.Models.CustomerPhoneModel>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerPhoneModel>("phone/GetById", Command);

            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.CustomerPhoneModel>();
                model.WithError(ex.Message);
            }

            return model;

        }

        [HttpGet]
        private async Task<IActionResult> GetPhoneJson(long phoneId)
        {
            var model = await GetPhone(phoneId);

            return Json(
               new
               {
                   IsSuccess = model.IsSuccess,
                   Errors = model.GetErrors(),
                   value = model.Value
               });

        }
    }
}
