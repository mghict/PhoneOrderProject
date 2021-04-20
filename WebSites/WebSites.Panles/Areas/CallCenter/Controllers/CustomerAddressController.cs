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
using WebSites.Panles.Models.CustomerAddress;
using WebSites.Panles.Services.CustomerAddress;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class CustomerAddressController : BaseController
    {
        protected  IGetAddressByIdService GetAddressByIdService;
        protected IGetCustomerAddressService GetCustomerAddressService;
        private Services.ISettingFacad _SettingFacad;
        private Services.Map.NeshanMapService MapService;
        public CustomerAddressController(Services.Map.NeshanMapService mapService,Services.ISettingFacad SettingFacad,IGetAddressByIdService getAddressByIdService, IGetCustomerAddressService getCustomerAddressService, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            GetAddressByIdService = getAddressByIdService;
            GetCustomerAddressService = getCustomerAddressService;
            _SettingFacad = SettingFacad;
            MapService = mapService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long customerId)
        {
            ViewBag.CustomerId = customerId;
            var model = await GetCustomerAddressService.ExecuteGetAddresses(customerId);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> PartialGetAllViewRegister(long customerId)
        {
            ViewBag.CustomerId = customerId;
            var model = await GetCustomerAddressService.ExecuteGetAddresses(customerId);
            return PartialView("CustomerAddressesforOrderRegisterPartialView", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long addressId)
        {
            try
            {
                var model = new
                {
                    Id = addressId
                };

                var ret = await ServiceCaller.PostDataWithoutValue("Address/remove", model);

                if (ret != null)
                {
                    if(ret.IsSuccess)
                    {
                        CacheService.ClearTokenAsync(TokenCachClass.CustomerAddressesAdd).Wait();
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

            var taskFill= FillViewBag();

            

            CustomerAddressRegisterModel model =
                new CustomerAddressRegisterModel()
                {
                    CustomerId= customerId
                };

            Task.WaitAll(taskFill);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CustomerAddressRegisterModel model,string latStr,string lngStr,string returnUrl)
        {
            var fill= FillViewBag();

            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;

            float temp = 0.0f;

            try
            {
                model.Status = 1;

                float.TryParse(latStr, style, info, out temp);
                model.Latitude = temp;

                float.TryParse(lngStr, style, info, out temp);
                model.Longitude = temp;

                model.AddressValue = model.AddressValue.Trim().Replace("  ","").Replace(Environment.NewLine," ");

                if (ModelState.IsValid)
                {

                    var ret = await ServiceCaller.PostDataWithoutValue("Address/Create", model);

                    if (ret != null)
                    {

                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        ViewBag.ReturnUrl = null;
                        fill.Dispose();
                        CacheService.ClearTokenAsync(TokenCachClass.CustomerAddressesAdd).Wait();
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    //ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
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
        public async Task<IActionResult> Update(long addressId)
        {
            await FillViewBag();
            var input = await GetAddressByIdService.ExecuteGetAddressById(addressId);
            var model = Mapper.Map<Models.CustomerAddress.CustomerAddressUpdateModel>(input);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerAddressUpdateModel model, string latStr, string lngStr, string returnUrl)
        {
            var fill = FillViewBag();

            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;

            float temp = 0.0f;

            try
            {
                float.TryParse(latStr, style, info, out temp);
                model.Latitude = temp;

                float.TryParse(lngStr, style, info, out temp);
                model.Longitude = temp;

                model.AddressValue = model.AddressValue.Trim().Replace("  ", "").Replace(Environment.NewLine, " ");

                if (ModelState.IsValid)
                {

                    var ret = await ServiceCaller.PostDataWithoutValue("Address/update", model);

                    if (ret != null)
                    {

                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        ViewBag.ReturnUrl = null;
                        fill.Dispose();
                        CacheService.ClearTokenAsync(TokenCachClass.CustomerAddressesAdd).Wait();
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    
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
        public async Task<IActionResult> ShowAddress(long addressId)
        {
            var address = await GetAddress(addressId);
            var model = address.Value;
            return View(model);
        }


        //-----------------------------------------------------
        //-----------------------------------------------------

        private async Task FillViewBag()
        {
            await Task.Run(() =>
            {
                var sts = StaticValues.GetStatuses;
                var addressSts = sts.Where(p => p.Subject.Equals("CustomerAddressStatus"));
                ViewBag.AddressStatus = new SelectList(addressSts, "StatusId", "Name");

                var addressType = sts.Where(p => p.Subject.Equals("CustomerAddressType"));
                ViewBag.AddressType = new SelectList(addressType, "StatusId", "Name");

                ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();

                var province = _SettingFacad.CityAndProvinceService.GetAllProvinceAsync();
                ViewBag.ProvinceList = new SelectList(province.Result, "Id", "ProvinceName");
            });
            
        }

        private async Task<FluentResult<BehsamFramework.Models.CustomerAddressModel>> GetAddress(long addressId)
        {

            var Command = new
            {
                Id = addressId
            };

            FluentResult<BehsamFramework.Models.CustomerAddressModel> model =
                new FluentResult<BehsamFramework.Models.CustomerAddressModel>();

            try
            {
                model =await ServiceCaller.PostDataWithValue<BehsamFramework.Models.CustomerAddressModel>("Address/GetById", Command);

            }
            catch (Exception ex)
            {
                model = new FluentResult<BehsamFramework.Models.CustomerAddressModel>();
                model.WithError(ex.Message);
            }

            return model;

        }
        private async Task<IActionResult> GetAddressJson(long addressId)
        {
            var model = await GetAddress(addressId);

            return Json(
               new
               {
                   IsSuccess = model.IsSuccess,
                   Errors = model.GetErrors(),
                   value = model.Value
               });

        }
        private async Task<List<BehsamFramework.Models.CustomerAddressModel>> GetAddresses(long customerId)
        {
            var model =await Task.Run(() =>
              {
                  List<BehsamFramework.Models.CustomerAddressModel> ret =
                      new List<BehsamFramework.Models.CustomerAddressModel>();

                  string cashedKey = "CustomerAddress" + customerId;

                  try
                  {
                      ret = CacheService.GetOrSet(ret,
                          customerId,
                          cashedKey,
                          TimeSpan.FromMinutes(10),
                          TimeSpan.FromMinutes(5),
                          CacheItemPriority.Low,
                          TokenCachClass.CustomerAddressesAdd,
                          GetCustomerAddresses);

                  }
                  catch 
                  {
                      ret = new List<BehsamFramework.Models.CustomerAddressModel>();
                  }

                  return ret;
              });

            return model;
        }
        private List<BehsamFramework.Models.CustomerAddressModel> GetCustomerAddresses(long customerId)
        {
            var Command = new
            {
                Id = customerId
            };

            FluentResult<List<BehsamFramework.Models.CustomerAddressModel>> model =
                new FluentResult<List<BehsamFramework.Models.CustomerAddressModel>>();

            try
            {
                model = ServiceCaller.GetDataWithValue<List<BehsamFramework.Models.CustomerAddressModel>>("Address/GetCustomerAddresses?id="+customerId).Result;

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<BehsamFramework.Models.CustomerAddressModel>>();
                model.WithError(ex.Message);
            }

            return model.Value;
        }

        //-----------------------------------------------------
        //-----------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> GetCity(float id)
        { 
            var model = await _SettingFacad.CityAndProvinceService.GetAllCityByProvinceAsync(id);

            var items = model.Select(s => new {
                Id=s.Id,
                Name=s.CityName
            }).ToList();

            return Json(new { Items=items });
        }

        [HttpPost]
        public async Task<IActionResult> GetArea(int id)
        {
            var model = await _SettingFacad.AreaInfoService.GetByCityAsync(id, 2);

            var items = model.Select(s => new {
                Id = s.Id,
                Name = s.AreaName,
                s.CenterLatitude
            }).ToList();

            return Json(new { Items = items });
        }

        [HttpPost]
        public async Task<IActionResult> GetGeo(int id)
        {
            var model = await _SettingFacad.AreaInfoService.GetByIdAsync(id);

            var item = new
            {
                lat = model.CenterLatitude.ToString(System.Globalization.CultureInfo.InvariantCulture),
                lng = model.Centerlongitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
            };

            return Json(new { Item = item });
        }

        [HttpPost]
        public async Task<IActionResult> GetSearchResult(string searchKey)
        {
            var model = await MapService.GeocodingApi(searchKey);

            var item = new
            {
                lat = model.Location.Y.ToString(System.Globalization.CultureInfo.InvariantCulture),
                lng = model.Location.X.ToString(System.Globalization.CultureInfo.InvariantCulture)
            };

            return Json(new { Item = item });
        }
    }
}
