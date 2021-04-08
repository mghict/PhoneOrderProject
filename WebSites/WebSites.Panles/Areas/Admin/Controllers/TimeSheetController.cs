using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TimeSheetController :BaseController
    {
        private Services.ISettingFacad _settingFacad;
        public TimeSheetController(Services.ISettingFacad SettingFacad,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _settingFacad = SettingFacad;
        }

        public async Task< IActionResult> Index()
        {
            var model=await _settingFacad.TimeSheetService.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Update(byte id)
        {
            var model =await _settingFacad.TimeSheetService.GetById(id);
            return View(model);
        }

        [HttpPost(Name = "Update")]
        public async Task<IActionResult> Update(Models.TimeSheet.StoreTimeSheetTbl model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var ret =await _settingFacad.TimeSheetService.UpdateTimeSheet(model.Id,model.StartTime,model.ToTime,model.StepTime,model.Status);

                    if (ret != null)
                    {
                        
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }
                        
                        CacheService.ClearToken(TokenCachClass.TimeSheetToken);

                        return Redirect("/Admin/TimeSheet/index");
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
                //return Json(new {IsSuccess=false,Errors=e.Message });

                ModelState.AddModelError("خطا", e.Message);
                return View("Update", model);
            }

        }
    }
}
