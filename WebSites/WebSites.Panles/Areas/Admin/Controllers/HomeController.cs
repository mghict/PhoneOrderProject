using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class HomeController : BaseController
    {
               
        private Services.Authorize.IAuthorizeService AuthorizeService;
        private readonly Hubs.IUserConnectionManager _userConnectionManager;


        public HomeController(
            Services.Authorize.IAuthorizeService authorizeService,
            Hubs.IUserConnectionManager UserConnectionManager,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            AuthorizeService = authorizeService;
            _userConnectionManager = UserConnectionManager;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            int applicationId = 1;


            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Json(new { IsSuccess = false, Errors = "اطلاعات وارد شده صحیح نمی باشد" });
            }

            try
            {

                long uname = Convert.ToInt64(userName);
                var result = AuthorizeService.Login(uname, password, applicationId);
                if (result.IsSuccess)
                {
                    Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
                    var connection = HttpContext.Connection.Id;
                    if (user != null)
                    {
                        _userConnectionManager.KeepUserConnection(user.UserId, connection, user);
                    }

                }
                return Json(new { IsSuccess = result.IsSuccess, Errors = result.GetErrors() });

            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Errors = "خطا \n" + ex.Message });

            }




        }

        [HttpGet]
        public IActionResult LogOut()
        {
            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");

                HttpContext.Session.Set("User", (Models.UserModel)null);
                HttpContext.User = null;

                _userConnectionManager.RemoveUser(user.UserId);
            }
            catch
            {

            }
            return Redirect("/Admin/Home/Login");
        }

        [HttpPost]
        public IActionResult ShowUserProfile()
        {
            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            return View(user);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ShowNotification()
        {
            Models.UserModel user = this.HttpContext.Session.Get<Models.UserModel>("User");
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
            Models.UserModel user = this.HttpContext.Session.Get<Models.UserModel>("User");
            if (user != null)
            {
                _userConnectionManager.RemoveUserNotification(user.UserId, id);

                return Json(new { IsSuccess = true });
            }

            return Json(new { IsSuccess = false });
        }
    }
}
