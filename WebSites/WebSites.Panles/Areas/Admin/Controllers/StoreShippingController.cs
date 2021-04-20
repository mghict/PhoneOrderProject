﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    public class StoreShippingController : BaseController
    {
        private Services.ISettingFacad _SettingFacad;
        
        public StoreShippingController(Services.ISettingFacad SettingFacad,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _SettingFacad = SettingFacad;
        }

        public async Task<IActionResult> StoreShipping(float storeId)
        {
            
            var model = await _SettingFacad.StoreShippingService.GetByStoreIdAsync(storeId);
            if(model==null || model.Id==0)
            {
                model = new Models.Store.StoreShippingTbl()
                {
                    Id = 0,
                    StoreID=storeId
                };
            }

            ViewBag.StoreId = storeId.ToString(CultureInfo.InvariantCulture);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StoreShipping(Models.Store.StoreShippingTbl model,string storeIdStr)
        {
            ViewBag.StoreId = storeIdStr;
            try
            {
                System.Globalization.CultureInfo info = CultureInfo.InvariantCulture;
                System.Globalization.NumberStyles style = NumberStyles.AllowDecimalPoint;
                float sId = 0.0f;

                float.TryParse(storeIdStr, style, info, out sId);

                model.StoreID = sId;

                //if(ModelState.IsValid)
                //{
                    FluentResult resp = new FluentResult();

                    if(model.Id==0)
                    {
                        resp = await _SettingFacad.StoreShippingService.Create(model);
                    }
                    else
                    {
                        resp = await _SettingFacad.StoreShippingService.Update(model);
                    }

                    if(!resp.IsSuccess)
                    {
                        ModelState.AddModelError("Error", resp.GetErrors());
                        return View("StoreShipping", model);
                    }

                    return Redirect("/Admin/Store/Index");
                //}
                //else
                //{
                //    return View("StoreShipping", model);
                //}
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("StoreShipping", model);
            }
            
        }




        //---------------------------------------------------
        //---------------------------------------------------

        public async Task<IActionResult> AreaShipping(float storeId, int cityId)
        {
            ViewBag.CityId = cityId;
            ViewBag.StoreId = storeId.ToString(CultureInfo.InvariantCulture);

            var model = await _SettingFacad.StoreShippingService.GetByStoreIdAreaAsync(storeId);

            return View(model);
        }



        public async Task<IActionResult> AddAreaShipping(float storeId, int cityId)
        {
            var lst = await _SettingFacad.AreaInfoService.GetByCityAsync(cityId, 2);

            ViewBag.AreaList = new SelectList(lst,"Id","AreaName");
            ViewBag.CityId = cityId;
            ViewBag.StoreId = storeId.ToString(CultureInfo.InvariantCulture);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAreaShipping(int cityId,string storeIdStr,Models.Store.StoreShippingAreaTbl model)
        {
            var lst = await _SettingFacad.AreaInfoService.GetByCityAsync(cityId, 2);

            ViewBag.AreaList = new SelectList(lst, "Id", "AreaName");
            ViewBag.CityId = cityId;
            ViewBag.StoreId = storeIdStr; 

            try
            {
                System.Globalization.CultureInfo info = CultureInfo.InvariantCulture;
                System.Globalization.NumberStyles style = NumberStyles.AllowDecimalPoint;
                float sId = 0.0f;

                float.TryParse(storeIdStr, style, info, out sId);

                model.StoreID = sId;

                var resp = await _SettingFacad.StoreShippingService.CreateArea(model);
                if(resp.IsSuccess)
                {
                    return Redirect($"/Admin/StoreShipping/AreaShipping?storeId={sId.ToString(CultureInfo.InvariantCulture)}&cityId={cityId}");
                }

                ModelState.AddModelError("Error", resp.GetErrors());
                return View("AddAreaShipping", model);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddAreaShipping", model);
            }
        }



        public async Task<IActionResult> UpdateAreaShipping(int cityId,int id)
        {
            var lst =  _SettingFacad.AreaInfoService.GetByCityAsync(cityId, 2);
            var model = _SettingFacad.StoreShippingService.GetByIdAreaAsync(id);

            Task.WaitAll(lst, model);

            ViewBag.CityId = cityId;
            ViewBag.StoreId = model.Result.StoreID.ToString(CultureInfo.InvariantCulture);
            ViewBag.AreaList = new SelectList(lst.Result, "Id", "AreaName");
            return View(model.Result);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateAreaShipping(int cityId, string storeIdStr, Models.Store.StoreShippingAreaTbl model)
        {
            var lst = await _SettingFacad.AreaInfoService.GetByCityAsync(cityId, 2);

            ViewBag.AreaList = new SelectList(lst, "Id", "AreaName");
            ViewBag.CityId = cityId;
            ViewBag.StoreId = storeIdStr;

            try
            {
                System.Globalization.CultureInfo info = CultureInfo.InvariantCulture;
                System.Globalization.NumberStyles style = NumberStyles.AllowDecimalPoint;
                float sId = 0.0f;

                float.TryParse(storeIdStr, style, info, out sId);

                model.StoreID = sId;

                var resp = await _SettingFacad.StoreShippingService.UpdateArea(model);
                if (resp.IsSuccess)
                {
                    return Redirect($"/Admin/StoreShipping/AreaShipping?storeId={sId.ToString(CultureInfo.InvariantCulture)}&cityId={cityId}");
                }

                ModelState.AddModelError("Error", resp.GetErrors());
                return View("UpdateAreaShipping", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("UpdateAreaShipping", model);
            }
        }



        [HttpPost]
        public async Task<IActionResult> DeleteAreaShipping(int id)
        {

            try
            {
                var resp = await _SettingFacad.StoreShippingService.DeleteArea(id);
                return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}