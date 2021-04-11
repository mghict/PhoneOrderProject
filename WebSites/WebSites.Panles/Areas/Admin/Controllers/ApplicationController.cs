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
    
    public class ApplicationController : BaseController
    {
        private Services.IUserFacad _userFacad;
        public ApplicationController(Services.IUserFacad UserFacad,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _userFacad = UserFacad;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _userFacad.ApplicationService.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _userFacad.ApplicationService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Authorize.ApplicationInfoModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var rest =await _userFacad.ApplicationService.Update(model);
                    if(rest.IsSuccess)
                    {
                        return Redirect("/Admin/Application/Index");
                    }

                    ModelState.AddModelError("Error", rest.GetErrors());
                    return View("Update", model);
                }
                else
                {
                    return View("Update", model);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("Update",model);
            }
            
        }


        //----------------------------
        // Pages
        //----------------------------
        [HttpPost]
        //Ajax
        public IActionResult RemovePages(int id)
        {
            var model = _userFacad.PageService.Delete(id).Result;
            return Json(new { IsSuccess = model.IsSuccess, Message = model.GetErrors() });
        }
        
        //------------------------
        // Page Parents
        //------------------------

        public async Task<IActionResult> AppPages(int appId)
        {
            ViewBag.AppId = appId;
            ViewBag.AppName = (await _userFacad.ApplicationService.GetById(appId)).ApplicationName;

            var model = await _userFacad.PageService.GetByApplicationIdParents(appId);
            return View(model);
        }
        public async Task<IActionResult> AddPages(int appId)
        {
            ViewBag.AppId = appId;
            ViewBag.AppName = (await _userFacad.ApplicationService.GetById(appId)).ApplicationName;

            var model = new Models.Authorize.PageInfoModel()
            {
                ApplicationId = appId,
                ParentId = 0
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPages(Models.Authorize.PageInfoModel model)
        {
            ViewBag.AppId = model.ApplicationId;
            ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.PageService.Create(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("AddPages", model);
                    }

                    return Redirect($"/Admin/Application/AppPages?appId={model.ApplicationId}");
                }
                else
                {
                    return View("AddPages", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddPages", model);
            }

        }

        public async Task<IActionResult> UpdatePages(int pageId)
        {
            var model = await _userFacad.PageService.GetById(pageId);

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;
                ViewBag.PageName = model.DisplayName;
                ViewBag.PageId = model.Id;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePages(Models.Authorize.PageInfoModel model)
        {
            var item = await _userFacad.PageService.GetById(model.Id);

            if (model != null)
            {
                ViewBag.AppId = item.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(item.ApplicationId)).ApplicationName;
                ViewBag.PageName = item.DisplayName;
                ViewBag.PageId = item.Id;
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.PageService.Update(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("UpdatePages", model);
                    }

                    return Redirect($"/Admin/Application/AppPages?appId={model.ApplicationId}");
                }
                else
                {
                    return View("UpdatePages", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("UpdatePages", model);
            }
        }

        //------------------------
        // Page Childs
        //------------------------
        public async Task<IActionResult> AppPagesChild(int pageId)
        {
            var item = await _userFacad.PageService.GetById(pageId);
            
            ViewBag.PageId = pageId;
            ViewBag.PageName = item.DisplayName;
            ViewBag.AppId = item.ApplicationId;
            ViewBag.AppName = (await _userFacad.ApplicationService.GetById(item.ApplicationId)).ApplicationName;

            var model = await _userFacad.PageService.GetByParentId(pageId);
            return View(model);
        }

        public async Task<IActionResult> AddPagesChild(int appId,int pageId)
        {
            ViewBag.AppId = appId;
            ViewBag.PageId = pageId;

            ViewBag.AppName =(await _userFacad.ApplicationService.GetById(appId)).ApplicationName;
            ViewBag.PageName =(await _userFacad.PageService.GetById(pageId)).DisplayName;

            var model = new Models.Authorize.PageInfoModel()
            {
                ApplicationId = appId,
                ParentId = pageId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPagesChild(Models.Authorize.PageInfoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.PageService.Create(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("AddPages", model);
                    }

                    return Redirect($"/Admin/Application/AppPagesChild?pageId={model.ParentId}");
                }
                else
                {
                    return View("AddPages", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddPages", model);
            }

        }


        public async Task<IActionResult> UpdatePagesChild(int pageId)
        {
            var model = await _userFacad.PageService.GetById(pageId);

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;
                ViewBag.PageName = model.DisplayName;
                ViewBag.PageId = model.Id;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePagesChild(Models.Authorize.PageInfoModel model)
        {
            var item = await _userFacad.PageService.GetById(model.Id);

            if (model != null)
            {
                ViewBag.AppId = item.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(item.ApplicationId)).ApplicationName;
                ViewBag.PageName = item.DisplayName;
                ViewBag.PageId = item.Id;
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.PageService.Update(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("UpdatePagesChild", model);
                    }

                    return Redirect($"/Admin/Application/AppPagesChild?pageId={model.ParentId}");
                }
                else
                {
                    return View("UpdatePagesChild", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("UpdatePagesChild", model);
            }
        }
    }
}
