using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Stores.Controllers
{
    public class HomeController : Base.BaseController
    {
        public HomeController(ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
            return Redirect("/Stores/Home/Login");
        }
    }
}
