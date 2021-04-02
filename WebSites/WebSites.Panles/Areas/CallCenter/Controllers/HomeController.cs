using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Hubs;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class HomeController : Controller
    {
        private readonly Hubs.IUserConnectionManager _userConnectionManager;
        private readonly IHttpContextAccessor ContextAccessor;

        public HomeController(IUserConnectionManager userConnectionManager,
            IHttpContextAccessor contextAccessor)
        {
            _userConnectionManager = userConnectionManager;
            ContextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ShowNotification()
        {
            Models.UserModel user = ContextAccessor.HttpContext.Session.Get<Models.UserModel>("User");
            List<Models.NotificationMessage> messages = new List<Models.NotificationMessage>();
            if(user!=null)
            {
                messages = _userConnectionManager.GetUserNotification(user.UserId);
            }
            return View(messages);
        }
    }
}
