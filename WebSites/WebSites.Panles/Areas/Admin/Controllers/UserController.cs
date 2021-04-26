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
    public class UserController : BaseController
    {
        private Services.IUserFacad _userFacad;
        public UserController(Services.IUserFacad UserFacad, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _userFacad = UserFacad;
        }

        public async Task<IActionResult> Index(string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            var lst = await _userFacad.UserService.GetAllSearchAsync(searchKey, pageNumber, pageSize);

            return View(lst);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(Models.Authorize.UserRegisterModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ret = await _userFacad.UserService.CreateAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.GetErrors());
                        return View("AddUser", usr);
                    }

                    return Redirect("/Admin/User/Index");
                }
                else
                {
                    return View("AddUser", usr);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddUser", usr);
            }

        }

        public async Task<IActionResult> EditUser(int userId)
        {
            var item = await _userFacad.UserService.GetByIdAsync(userId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Models.Authorize.UserInfoModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ret = await _userFacad.UserService.UpdateAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.GetErrors());
                        return View("EditUser", usr);
                    }

                    return Redirect("/Admin/User/Index");
                }
                else
                {
                    return View("EditUser", usr);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("EditUser", usr);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(int userId)
        {

            var ret = await _userFacad.UserService.DeleteAsync(userId);

            return Json(new { IsSuccess = ret.IsSuccess, Message = ret.GetErrors() });

        }


        public async Task<IActionResult> ResetAdminPass(int userId)
        {
            var item = await _userFacad.UserService.GetByIdAsync(userId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ResetAdminPass(Models.Authorize.UserInfoModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(usr.Password!=usr.PasswordConfirm || string.IsNullOrEmpty(usr.Password))
                    {
                        throw new Exception("رمزعبور و تایید آن مشابه نیستند");
                    }

                    var ret = await _userFacad.UserService.ResetAdminAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.GetErrors());
                        return View("ResetAdminPass", usr);
                    }

                    return Redirect("/Admin/User/Index");
                }
                else
                {
                    return View("ResetAdminPass", usr);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("ResetAdminPass", usr);
            }
        }

        public async Task<IActionResult> ResetPass()
        {
            var item = new Models.Authorize.UserInfoModel();

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                var userId = user.UserId;
                item = await _userFacad.UserService.GetByIdAsync(userId);
            }

           
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPass(Models.Authorize.UserInfoModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usr.Password != usr.PasswordConfirm || string.IsNullOrEmpty(usr.Password))
                    {
                        throw new Exception("رمزعبور و تایید آن مشابه نیستند");
                    }

                    var ret = await _userFacad.UserService.ResetUserAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.GetErrors());
                        return View("ResetPass", usr);
                    }

                    return Redirect("/Admin/Home/Index");
                }
                else
                {
                    return View("ResetPass", usr);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("ResetPass", usr);
            }
        }
        //---------------------------------------------
        //---------------------------------------------

        public async Task<IActionResult> ShowRoles(int userId)
        {
            var lst = await _userFacad.UserService.GetByUserId(userId);
            
            ViewBag.UserId = userId;
            ViewBag.UserName = (await _userFacad.UserService.GetByIdAsync(userId)).Name;

            return View(lst);
        }

        public async Task<IActionResult> AddRoles(int userId)
        {
            
            var applst = await _userFacad.ApplicationService.GetAll();

            ViewBag.AppList = new SelectList(applst.Where(p=>p.Status==true).ToList(),"Id","ApplicationName");
            ViewBag.UserId = userId;
            ViewBag.UserName = (await _userFacad.UserService.GetByIdAsync(userId)).Name;

            return View();
        }

        public async Task<IActionResult> GetRolesByApp(int appId)
        {
            var lst = await _userFacad.RoleService.GetByApplicationId(appId);
            var data=lst.Where(p => p.Status == true).Select(s => new
                                                                    {
                                                                        Id = s.Id,
                                                                        RoleName = s.RoleName
                                                                    }).ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoles(int userId,int roleId,bool status)
        {
            var applst = await _userFacad.ApplicationService.GetAll();

            ViewBag.AppList = new SelectList(applst.Where(p => p.Status == true).ToList(), "Id", "ApplicationName");
            ViewBag.UserId = userId;
            ViewBag.UserName = (await _userFacad.UserService.GetByIdAsync(userId)).Name;

            try
            {
                var model = new Models.Authorize.UserRoleModel()
                {
                    RoleId = roleId,
                    UserId = userId,
                    Status = status
                };

                var resp = await _userFacad.UserService.CreateRoleAsync(model);
                if(resp.IsFailed)
                {
                    ModelState.AddModelError("Error", resp.GetErrors());
                    return View("AddRoles", userId);
                }

                return Redirect($"/Admin/User/ShowRoles?userId={userId}");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("AddRoles", userId);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(int id)
        {
            var resp = await _userFacad.UserService.DeleteRoleAsync(id);

            return Json(new {IsSuccess=resp.IsSuccess,Message=resp.GetErrors() });
        }
    }
}
