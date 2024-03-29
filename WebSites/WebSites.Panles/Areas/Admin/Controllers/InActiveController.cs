﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using BehsamFramework.Util;
using BehsamFramework.Utility;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InActiveController : BaseController
    {
        private Services.ISettingFacad _settingFacad;
        public InActiveController(
            Services.ISettingFacad SettingFacad,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _settingFacad = SettingFacad;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _settingFacad.InActiveService.GetAll();
            model.OrderByDescending(p => p.Id);

            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            var model = new Models.InActive.InActiveActivity();
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var entity = await _settingFacad.InActiveService.GetById(id);

            var model = new Models.InActive.InActiveActivity()
            {
                Id = entity.Id,
                Status = entity.Status,
                Title = entity.Title,
                FromDate = entity.FromDate.ToPersianDate(),
                ToDate = entity.ToDate.ToPersianDate()
            };

            return View(model);
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(Models.InActive.InActiveActivity model)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    Models.InActive.InActiveTbl command = new Models.InActive.InActiveTbl()
                    {
                        Id = model.Id,
                        FromDate = model.FromDate.ToDateTime(),
                        ToDate = model.ToDate.ToDateTime(),
                        Status = model.Status,
                        Title = model.Title
                    };

                    var ret = await _settingFacad.InActiveService.Create(command);

                    if (ret != null)
                    {
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        return Redirect("/Admin/InActive/index");
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    return View("Register", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                return View("Register", model);
            }

        }

        [HttpPost(Name = "Update")]
        public async Task<IActionResult> Update(Models.InActive.InActiveActivity model)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    Models.InActive.InActiveTbl command = new Models.InActive.InActiveTbl()
                    {
                        Id = model.Id,
                        FromDate = model.FromDate.ToDateTime(),
                        ToDate = model.ToDate.ToDateTime(),
                        Status = model.Status,
                        Title = model.Title
                    };

                    var ret = await _settingFacad.InActiveService.Update(command);

                    if (ret != null)
                    {
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        return Redirect("/Admin/InActive/Index");
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    return View("Update", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                return View("Update", model);
            }

        }

        [HttpPost(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var ret = await _settingFacad.InActiveService.Remove(id);

                if (ret != null)
                {

                    return Json(new { IsSuccess = ret.IsSuccess, Errors = ret.GetErrors() });
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


        //---------------------------------------------------
        // StoreInActive
        //---------------------------------------------------

        public async Task<IActionResult> StoreInActive(string storeId)
        {
            var info = System.Globalization.CultureInfo.InvariantCulture;
            var style = System.Globalization.NumberStyles.AllowDecimalPoint;

            float sId = 0.0f;
            float.TryParse(storeId, style, info, out sId);

            var model = await _settingFacad.InActiveService.GetAllStoreInActive(sId);



            ViewBag.StoreId = storeId;

            return View(model);
        }

        public async Task<IActionResult> StoreInActiveAdd(string storeId)
        {
            float sId = 0.0f;

            var info = System.Globalization.CultureInfo.InvariantCulture;
            var style = System.Globalization.NumberStyles.AllowDecimalPoint;



            float.TryParse(storeId, style, info, out sId);

            ViewBag.StoreId = storeId;
     


            Models.InActive.StoreInActiveModel model = new Models.InActive.StoreInActiveModel()
            {
                FromDate = System.DateTime.Now.AddDays(1).ToPersianDate(),
                ToDate = System.DateTime.Now.AddDays(1).ToPersianDate(),
                StoreId = storeId,
                Status=true
            };

            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> StoreInActiveAdd(Models.InActive.StoreInActiveModel model)
        {
            string strSid = model.StoreId;
            ViewBag.StoreId = strSid;

            float sId = 0.0f;

            var info = System.Globalization.CultureInfo.InvariantCulture;
            var style = System.Globalization.NumberStyles.AllowDecimalPoint;
            
            

            

            try
            {
                sId = float.Parse(strSid, style, info);

                if (ModelState.IsValid)
                {

                    

                    Models.InActive.StoreInActiveTbl command = new Models.InActive.StoreInActiveTbl()
                    {
                        Id = model.Id,
                        FromDate = model.FromDate.ToDateTime(),
                        ToDate = model.ToDate.ToDateTime(),
                        Status = model.Status,
                        StoreId = sId,
                        Title = model.Title
                    };

                    var ret = await _settingFacad.InActiveService.CreateStoreInActive(command);

                    if (ret != null)
                    {
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }

                        return Redirect($"/Admin/InActive/StoreInActive?storeId={model.StoreId}");
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    return View("StoreInActiveAdd", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                return View("StoreInActiveAdd", model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> StoreInActiveDel(int id)
        {
            var ret = await _settingFacad.InActiveService.RemoveStoreInActive(id);
            return Json(new {IsSuccess=ret.IsSuccess,Message=ret.GetErrors()});

        }
    }
}
