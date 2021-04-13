using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using System.Linq;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private Services.IUserFacad _userFacad;
        public RoleController(Services.IUserFacad UserFacad, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _userFacad = UserFacad;
        }

        public async Task<IActionResult> AppRoles(int appId)
        {
            var model = await _userFacad.RoleService.GetByApplicationId(appId);
            return View(model);
        }

        public async Task<IActionResult> AddRole(int appId)
        {
            var model =new  Models.Authorize.RoleInfoModel()
            {
                ApplicationId=appId
            };

            ViewBag.AppId = appId;
            ViewBag.AppName = (await _userFacad.ApplicationService.GetById(appId)).ApplicationName;

            return View(model);
        }

        public async Task<IActionResult> UpdateRole(int roleId)
        {
            var model = await _userFacad.RoleService.GetById(roleId);

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

                ViewBag.RoleId = model.Id;
                ViewBag.RoleName = model.RoleName;
            }

            return View(model);
        }

        public async Task<IActionResult> GetPermisions(int roleId)
        {
            var model = await _userFacad.RoleService.GetById(roleId);

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

                ViewBag.RoleId = model.Id;
                ViewBag.RoleName = model.RoleName;
            };

            var lst =await _userFacad.RoleService.GetPermisionsAsync(roleId);

            return View(lst);
        }

        
        [HttpPost]
        //Ajax
        public IActionResult RemoveRole(int id)
        {
            var model = _userFacad.RoleService.DeleteAsync(id).Result;
            return Json(new { IsSuccess = model.IsSuccess, Message = model.GetErrors() });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(Models.Authorize.RoleInfoModel model)
        {
          

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

                ViewBag.RoleId = model.Id;
                ViewBag.RoleName = model.RoleName;
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.RoleService.UpdateAsync(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("UpdateRole", model);
                    }

                    return Redirect($"/Admin/Role/AppRoles?appId={model.ApplicationId}");
                }
                else
                {
                    return View("UpdateRole", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("UpdateRole", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Models.Authorize.RoleInfoModel model)
        {


            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

                ViewBag.RoleId = model.Id;
                ViewBag.RoleName = model.RoleName;
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userFacad.RoleService.CreateAsync(model);
                    if (result.IsFailed)
                    {
                        ModelState.AddModelError("Error", result.GetErrors());
                        return View("AddRole", model);
                    }

                    return Redirect($"/Admin/Role/AppRoles?appId={model.ApplicationId}");
                }
                else
                {
                    return View("AddRole", model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddRole", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermisions(int roleId, List<int> pageIds)
        {
            var model = await _userFacad.RoleService.GetById(roleId);

            if (model != null)
            {
                ViewBag.AppId = model.ApplicationId;
                ViewBag.AppName = (await _userFacad.ApplicationService.GetById(model.ApplicationId)).ApplicationName;

                ViewBag.RoleId = model.Id;
                ViewBag.RoleName = model.RoleName;
            };

            var lst = await _userFacad.RoleService.GetPermisionsAsync(roleId);

            foreach (var item in lst)
            {
                item.IsAccess = false;

                if (pageIds.Contains(item.PageId))
                {
                    item.IsAccess = true;
                }
            }

            var resp =await _userFacad.RoleService.CreatePermisionsAsync(lst);

            return Json(new { IsSuccess = resp.IsSuccess, Message = resp.GetErrors() });
        }

        [HttpPost]
        public async Task<IActionResult> AddPermision(int pageId,int roleId)
        {
            var model = new List<Models.Authorize.PermistionModel>();

            model.Add(new Models.Authorize.PermistionModel()
            {
                PageId = pageId,
                RoleId = roleId,
                IsAccess = true
            });


            var result = await _userFacad.RoleService.CreatePermisionsAsync(model);

            return Json(new { IsSuccess = result.IsSuccess });
        }

        [HttpPost]
        public async Task<IActionResult> RemovePermision(int pageId, int roleId)
        {
            var model = new List<Models.Authorize.PermistionModel>();

            model.Add(new Models.Authorize.PermistionModel()
            {
                PageId = pageId,
                RoleId = roleId,
                IsAccess = false
            });


            var result = await _userFacad.RoleService.CreatePermisionsAsync(model);

            return Json(new { IsSuccess = result.IsSuccess });
        }
    }
}
