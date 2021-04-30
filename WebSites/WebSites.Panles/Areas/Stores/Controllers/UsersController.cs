using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;
using System.Globalization;

namespace WebSites.Panles.Areas.Stores.Controllers
{
    public class UsersController : Base.BaseController
    {
        private Services.IUserFacad _userFacad;

        public UsersController(
            Services.IUserFacad UserFacad,
        ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _userFacad = UserFacad;
            
        }

        public IActionResult Index(string act="")
        {
            if(act.ToLower().Equals("jourchin"))
            {
                return Redirect("/Stores/Users/JourChinUsers");
            }
            else if (act.ToLower().Equals("safir"))
            {
                return Redirect("/Stores/Users/SafirUsers");
            }
            else
            {
                return View();
            }
            
        }

        public async Task<IActionResult> SafirUsers(string searchKey = "", int page = 0,int pageSize=20)
        {
            var model = new Models.Authorize.UserModel()
            {
               RowCount=0,
               Users=new List<Models.Authorize.UserInfo>()
            };

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                model = await _userFacad.UserService.GetAllSearchByAppIdAndStoreIdAsync(5, sId,searchKey,page,pageSize);
            }
            
            return View(model);
        }
        public async Task<IActionResult> JourChinUsers(string searchKey = "", int page = 0, int pageSize = 20)
        {
            var model = new Models.Authorize.UserModel()
            {
                RowCount = 0,
                Users = new List<Models.Authorize.UserInfo>()
            };


            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                model = await _userFacad.UserService.GetAllSearchByAppIdAndStoreIdAsync(4, sId, searchKey, page, pageSize);

            }

            return View(model);
        }


        //------------------------------------
        //------------------------------------

        public async Task<IActionResult> ResetAdminPass(int userId, string act="")
        {
            ViewBag.BackUrl = act;

            var item = await _userFacad.UserService.GetByIdAsync(userId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ResetAdminPass(Models.Authorize.UserInfoModel usr, string act="")
        {
            ViewBag.BackUrl = act;

            try
            {
                if (ModelState.IsValid)
                {
                    if (usr.Password != usr.PasswordConfirm || string.IsNullOrEmpty(usr.Password))
                    {
                        throw new Exception("رمزعبور و تایید آن مشابه نیستند");
                    }

                    var ret = await _userFacad.UserService.ResetAdminAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.GetErrors());
                        return View("ResetAdminPass", usr);
                    }

                    return Redirect($"/Stores/Users/Index?act={act}");
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

        //------------------------------------
        //------------------------------------

        public async Task<IActionResult> ShowRoles(int userId,string act)
        {
            var lst = await _userFacad.UserService.GetByUserId(userId);

            ViewBag.UserId = userId;
            ViewBag.UserName = (await _userFacad.UserService.GetByIdAsync(userId)).Name;
            ViewBag.BackUrl = act;

            return View(lst);
        }

        //-----------------------------------
        //-----------------------------------

        public IActionResult AddUser(string act="")
        {
            ViewBag.BackUrl = act;

            var model = new Models.Authorize.UserRegisterModel();
            var user = HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                model = new Models.Authorize.UserRegisterModel()
                {
                    Storeid = sId,
                    Status = true
                };
            }

            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(Models.Authorize.UserRegisterModel usr,string act="")
        {
            ViewBag.BackUrl = act;
            int roleId = 0;
            bool valid = false;
            if (act.ToLower().Equals("jourchin") )
            {
                valid = true;
                roleId = 4;
            }

            if (act.ToLower().Equals("safir"))
            {
                valid = true;
                roleId = 5;
            }



            try
            {
                if (!valid)
                {
                    throw new Exception("نوع کاربر صحیح نمی باشد");
                }

                if (ModelState.IsValid)
                {
                    long userName = Convert.ToInt64(usr.UserName);
                    var existsUser = await _userFacad.UserService.GetByUserNameAsync(userName);

                    if (existsUser == null)
                    {

                        var ret = await _userFacad.UserService.CreateAsync(usr);
                        if (ret.IsFailed || ret.Value <= 0)
                        {
                            ModelState.AddModelError("Error", ret.GetErrors());
                            return View("AddUser", usr);
                        }

                        var userRoleModel = new Models.Authorize.UserRoleModel()
                        {
                            RoleId = roleId,
                            Status = true,
                            UserId = ret.Value
                        };

                        var roleRet = await _userFacad.UserService.CreateRoleAsync(userRoleModel);

                        if (roleRet.IsFailed)
                        {
                            await _userFacad.UserService.DeleteAsync(ret.Value);

                            ModelState.AddModelError("Error", roleRet.GetErrors());
                            return View("AddUser", usr);
                        }
                    }
                    else
                    {
                        var roleLst = await _userFacad.UserService.GetByUserId(existsUser.Id);
                        var existsRole = roleLst.FirstOrDefault(p => p.RoleId == roleId);

                        if (existsRole == null)
                        {
                            var roleRetExists = await _userFacad.UserService.CreateRoleAsync(new Models.Authorize.UserRoleModel
                            {
                                RoleId = roleId,
                                UserId = existsRole.UserId,
                                Status=true
                            });

                            if (roleRetExists.IsFailed)
                            {
                                
                                ModelState.AddModelError("Error", roleRetExists.GetErrors());
                                return View("AddUser", usr);
                            }
                        }
                        else
                        {
                           throw new Exception("کاربر با نام کاربری و نقش مربوطه وجود دارد");
                        }
                        
                    }

                    return Redirect($"/Stores/Users/Index?act={act}");
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

        //-----------------------------------
        //-----------------------------------
        public async Task<IActionResult> EditUser(int userId,string act= "")
        {
            ViewBag.BackUrl = act;

            var item = await _userFacad.UserService.GetByIdAsync(userId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Models.Authorize.UserInfoModel usr, string act = "")
        {
            ViewBag.BackUrl = act;
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

                    return Redirect($"/Stores/Users/Index?act={act}");
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

        //-----------------------------------
        //-----------------------------------

        [HttpPost]
        public async Task<IActionResult> RemoveUser(int userId)
        {

            var ret = await _userFacad.UserService.DeleteAsync(userId);

            return Json(new { IsSuccess = ret.IsSuccess, Message = ret.GetErrors() });

        }
    }
}
