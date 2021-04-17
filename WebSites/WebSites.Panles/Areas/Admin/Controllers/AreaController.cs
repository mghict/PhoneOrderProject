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

namespace WebSites.Panles.Areas.Admin.Controllers
{
    public class AreaController : BaseController
    {
        private Services.ISettingFacad _settingFacad;
        public AreaController(Services.ISettingFacad SettingFacad,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _settingFacad = SettingFacad;
        }

        public async Task<IActionResult> Index(string searchKey="",int pageNumber=0,int pageSize=20)
        {
            var model = await _settingFacad.AreaInfoService.GetAllBySearchAsync(searchKey, pageNumber, pageSize);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveArea(int areaId)
        {
            var result = await _settingFacad.AreaInfoService.DeleteAsync(areaId);
            return Json(new { IsSuccess=result.IsSuccess,Message=result.GetErrors()});
        }

        public async Task<IActionResult> AddArea()
        {
            
            var city =  _settingFacad.CityAndProvinceService.GetAllCityAsync();
            var type =  _settingFacad.AreaInfoService.GetAllAreaTypeAsync();
            var parent = _settingFacad.AreaInfoService.GetAllAsync();

            Task.WaitAll(city, type,parent);

            ViewBag.AreaType = new SelectList(type.Result, "StatusId", "Name");
            ViewBag.City = new SelectList(city.Result,"Id","CityName");
            ViewBag.Parent = new SelectList(parent.Result,"Id", "AreaName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArea(Models.Area.AreaInfoModel model)
        {

            var city = _settingFacad.CityAndProvinceService.GetAllCityAsync();
            var type = _settingFacad.AreaInfoService.GetAllAreaTypeAsync();
            var parent = _settingFacad.AreaInfoService.GetAllAsync();

            try
            {
                model.CenterLatitude = 32.6859773f;
                model.Centerlongitude = 56.366282f;

                if(ModelState.IsValid)
                {
                    var result = await _settingFacad.AreaInfoService.CreateAsync(model);
                    if(result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("AddArea", model);
                    }

                    return Redirect("/admin/area/index");
                }
                else
                {
                    return View("AddArea", model);
                }
            }
            catch(Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                return View("AddArea", model);
            }
            finally
            {

                Task.WaitAll(city, type, parent);

                ViewBag.AreaType = new SelectList(type.Result, "StatusId", "Name");
                ViewBag.City = new SelectList(city.Result, "Id", "CityName");
                ViewBag.Parent = new SelectList(parent.Result, "Id", "AreaName");
            }
        }

        public async Task<IActionResult> UpdateArea(int areaId)
        {

            var city  =  _settingFacad.CityAndProvinceService.GetAllCityAsync();
            var type  =  _settingFacad.AreaInfoService.GetAllAreaTypeAsync();
            var parent = _settingFacad.AreaInfoService.GetAllAsync();

            var model =  _settingFacad.AreaInfoService.GetByIdAsync(areaId);

            Task.WaitAll(city, type, model,parent);

            ViewBag.AreaType = new SelectList(type.Result, "StatusId", "Name");
            ViewBag.City = new SelectList(city.Result, "Id", "CityName");
            ViewBag.Parent = new SelectList(parent.Result, "Id", "AreaName");

            return View(model.Result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArea(Models.Area.AreaInfoModel model)
        {

            var city = _settingFacad.CityAndProvinceService.GetAllCityAsync();
            var type = _settingFacad.AreaInfoService.GetAllAreaTypeAsync();
            var parent = _settingFacad.AreaInfoService.GetAllAsync();

            try
            {

                if(ModelState.IsValid)
                {
                    var result = await _settingFacad.AreaInfoService.UpdateAsync(model);
                    if(result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("UpdateArea", model);
                    }

                    return Redirect("/admin/area/index");
                }
                else
                {
                    return View("UpdateArea", model);
                }
            }
            catch(Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                return View("UpdateArea", model);
            }
            finally
            {

                Task.WaitAll(city, type, parent);

                ViewBag.AreaType = new SelectList(type.Result, "StatusId", "Name");
                ViewBag.City = new SelectList(city.Result, "Id", "CityName");
                ViewBag.Parent = new SelectList(parent.Result, "Id", "AreaName");
            }
        }

        public async Task<IActionResult> AreaChild(int areaId)
        {
            var areaTask = _settingFacad.AreaInfoService.GetByIdAsync(areaId);
            var modelTask =_settingFacad.AreaInfoService.GetByParentAsync(areaId);


            Task.WaitAll(areaTask, modelTask);

            ViewBag.AreaName = areaTask.Result?.AreaName ?? "";
            var model = modelTask.Result ?? new List<Models.Area.AreaInfoModel>();

            return View(model);
        }

        public async Task<IActionResult> AreaInfo(int areaId)
        {

            var model =await _settingFacad.AreaInfoService.GetByIdAsync(areaId);

            return View(model);
        }

        public async Task<IActionResult> UpdateLocation(int areaId)
        {

            var model =await _settingFacad.AreaInfoService.GetByIdAsync(areaId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(int Id,string lat,string lng)
        {

            var model = await _settingFacad.AreaInfoService.GetByIdAsync(Id);

            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;
            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
            float latF = 0.0f,lngF=0.0F;
            float.TryParse(lat, style, info, out latF);
            float.TryParse(lng, style, info, out lngF);

            model.CenterLatitude = latF>0?latF: model.CenterLatitude;
            model.Centerlongitude = lngF>0? lngF: model.Centerlongitude;

            try
            {
                var ret = await _settingFacad.AreaInfoService.UpdateAsync(model);
                if(ret.IsFailed)
                {
                    ModelState.AddModelError("Error", ret.GetErrors());
                    return View("UpdateLocation", model);
                }

                return Redirect("/Admin/Area/Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("UpdateLocation",model);
            }
            
        }

        public async Task<IActionResult> UpdatePolygon(int areaId)
        {

            var model = await _settingFacad.AreaInfoService.GetByIdAsync(areaId);

            return View(model);
        }
    }
}
