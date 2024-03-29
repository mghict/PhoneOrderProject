﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class LoginController : Controller
    {
        class modelLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public long ApplicationId { get; set; }
        }

        private Services.Authorize.IAuthorizeService AuthorizeService;
        private readonly Hubs.IUserConnectionManager _userConnectionManager;
        
        private Services.IUserFacad _userFacad;

        private readonly ServiceCaller<Token> Service;
        private readonly IHttpContextAccessor ContextAccessor;

        public LoginController(
            Services.IUserFacad UserFacad,
            IHttpClientFactory _clientFactory,
            Services.Authorize.IAuthorizeService authorizeService,
            Hubs.IUserConnectionManager UserConnectionManager,
            IHttpContextAccessor contextAccessor)
        {
            _userFacad = UserFacad;
            Service = new ServiceCaller<Token>(_clientFactory);
            AuthorizeService = authorizeService;
            _userConnectionManager = UserConnectionManager;
            ContextAccessor = contextAccessor;
        }


        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet(Name = "Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(Name = "Login")]
        public IActionResult Login(string userName, string password)
        {
            int applicationId = 2;
            

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Json(new { IsSuccess = false, Errors = "اطلاعات وارد شده صحیح نمی باشد" });
            }

            try
            {
                
                long uname = Convert.ToInt64(userName);
                var result=AuthorizeService.Login(uname, password, applicationId);
                if(result.IsSuccess)
                {
                    Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
                    var connection = HttpContext.Connection.Id;
                    if (user != null)
                    {
                        _userConnectionManager.KeepUserConnection(user.UserId, connection,user);
                        _userConnectionManager.SetNotification(user.UserId, new Models.NotificationMessage { messageBody = "Hi mostafa" });
                    }
                    
                }
                return Json(new { IsSuccess = result.IsSuccess, Errors = result.GetErrors() });

            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Errors = "خطا \n" + ex.Message });

            }




        }

        [HttpGet(Name = "LogOut")]
        public IActionResult LogOut()
        {
            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");

                HttpContext.Session.Set<Models.UserModel>("User", null);
                HttpContext.User = null;

                _userConnectionManager.RemoveUser(user.UserId);
            }
            catch
            {

            }
            return Redirect("/Callcenter/Login/Login");
        }

        [HttpPost]
        public IActionResult ShowUserProfile()
        {
            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            return View(user);
        }

        public IActionResult ShowNotification()
        {
            Models.UserModel user = ContextAccessor.HttpContext.Session.Get<Models.UserModel>("User");
            List<Models.NotificationMessage> messages = new List<Models.NotificationMessage>();
            if (user != null)
            {
                messages = _userConnectionManager.GetUserNotification(user.UserId);
            }
            return View(messages);
        }

        [HttpPost]
        public IActionResult DeleteNotification(long id)
        {
            Models.UserModel user = ContextAccessor.HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                _userConnectionManager.RemoveUserNotification(user.UserId, id);

                return Json(new { IsSuccess = true });
            }

            return Json(new { IsSuccess = false });
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

                    return Redirect("/CallCenter/Home/Index");
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
