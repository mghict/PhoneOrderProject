using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSites.Panles.Models;
using Microsoft.AspNetCore.SignalR;
using WebSites.Panles.Hubs;

namespace WebSites.Panles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private Services.Map.NeshanMapService NeshanMapService;
        public HomeController(Services.Map.NeshanMapService neshanMapService,ILogger<HomeController> logger, IHubContext<NotificationHub> notificationHubContext)
        {
            _logger = logger;
            _notificationHubContext = notificationHubContext;
            NeshanMapService = neshanMapService;
        }

        public IActionResult Index()
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

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendDate(NotificationMessage model)
        {
            await _notificationHubContext.Clients.All.SendAsync("sendToUser", model.messageHead, model.messageBody,model.messageType);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocation()
        {
            var rest = await NeshanMapService.GeocodingApi("تهران، خیابان شهید مدنی، خیابان بخشی فرد، کوچه علیرضا محمدی پلاک 11");
            return Json(rest);
        }

        [HttpGet]
        public async Task<IActionResult> GetRLocation()
        {
            var res = await NeshanMapService.GeocodingApi("تهران، خیابان شهید مدنی، خیابان بخشی فرد، کوچه علیرضا محمدی پلاک 11");

            var lat = res.Location.Y;
            var lng = res.Location.X;

            var rest = await NeshanMapService.ReverseGeocodingApi(lat, lng);
            return Json(rest);
        }
    }
    
}
