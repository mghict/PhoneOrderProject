using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.JourChin.Helper;
using WebSite.JourChin.Models;
using WebSite.JourChin;

namespace WebSite.JourChin.Controllers
{
    public class HomeController : Base.BaseController
    {
        private readonly Services.Authorize.IAuthorizeService _authorizeService;
        private readonly Services.User.IUserService _userService;
        public HomeController(Services.User.IUserService UserService,Services.Authorize.IAuthorizeService AuthorizeService,ServiceCaller serviceCaller, ICachedMemoryService _cacheService, IMapper mapper) : base(serviceCaller, _cacheService, mapper)
        {
            _authorizeService = AuthorizeService;
            _userService = UserService;
        }

        public async Task< IActionResult> Index()
        {
            return View();
        }


        //Login
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            int applicationId = 4;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Json(new { IsSuccess = false, Errors = "اطلاعات وارد شده صحیح نمی باشد" });
            }

            //return Json(new { IsSuccess = true, Errors = "" });

            try
            {

                long uname = Convert.ToInt64(userName);
                var result = _authorizeService.Login(uname, password, applicationId);

                var errors = result.Errors.Select(p => p.Message).ToList().ListToString();

                

                return Json(new { IsSuccess = result.IsSuccess, Errors = errors });

                

            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Errors = "خطا \n" + ex.Message });

            }

        }


        //LogOut
        [HttpPost]
        public IActionResult LogOut()
        {
            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");

                HttpContext.Session.Set("User", (Models.UserModel)null);
                HttpContext.User = null;

                //_userConnectionManager.RemoveUser(user.UserId);
            }
            catch
            {

            }
            return Redirect("/Home/Login");
        }


        //ShowUserProfile
        [HttpPost]
        public IActionResult ShowUserProfile()
        {
            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            return View(user);
        }

        //Other
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ResetPass()
        {
            var item = new Models.User.UserInfoModel();

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                var userId = user.UserId;
                item = await _userService.GetByIdAsync(userId);
            }


            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPass(Models.User.UserInfoModel usr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usr.Password != usr.PasswordConfirm || string.IsNullOrEmpty(usr.Password))
                    {
                        throw new Exception("رمزعبور و تایید آن مشابه نیستند");
                    }

                    var ret = await _userService.ResetUserAsync(usr);
                    if (ret.IsFailed)
                    {
                        ModelState.AddModelError("Error", ret.Errors.Select(s=>s.Message).ToList().ListToString());
                        return View("ResetPass", usr);
                    }

                    return Redirect("/Home/Index");
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
    }
}
