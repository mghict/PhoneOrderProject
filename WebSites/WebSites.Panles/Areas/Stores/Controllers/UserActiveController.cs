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
    public class UserActiveController : Base.BaseController
    {
        private Services.IUserFacad _UserFacad;
        private Services.IOrderFacad _OrderFacad;
        public UserActiveController(Services.IOrderFacad OrderFacad,Services.IUserFacad UserFacad,ServiceCaller serviceCaller, IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(serviceCaller, memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _UserFacad = UserFacad;
            _OrderFacad = OrderFacad;
        }

        public async Task<IActionResult> Index(string searchkey="",int pageNumber=0,int pageSize=20)
        {
            
            return View();
        }

        public async Task<IActionResult> JourChinUserActive(string searchkey = "", int page = 0, int pageSize = 20)
        {
            var model = new Models.Authorize.UserModel();

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                model = await _UserFacad.UserActivityService.GetAllUserActiveCurrentDateAsync(4, sId, searchkey, page, pageSize, 100);
            }

            ViewBag.BackUrl = "JourChin";

            return View(model);
        }

        public async Task<IActionResult> SafirUserActive(string searchkey = "", int page = 0, int pageSize = 20)
        {
            var model = new Models.Authorize.UserModel();

            var user = HttpContext.Session.Get<Models.UserModel>("User");

            if (user != null)
            {
                float sId = 0.0f;
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                CultureInfo info = CultureInfo.InvariantCulture;

                float.TryParse(user.StoreId, style, info, out sId);

                model = await _UserFacad.UserActivityService.GetAllUserActiveCurrentDateAsync(5, sId, searchkey, page, pageSize, 100);
            }

            ViewBag.BackUrl = "Safir";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUser(int userId,int status)
        {

            try
            {
                var model = new Models.Authorize.UserActivityModel()
                {
                    CreateDate=DateTime.Now,
                    Status=status,
                    UserId=userId,
                    Id=0
                };

                var ret = await _UserFacad.UserActivityService.UpdateStatusAsync(model);

                return Json(new { IsSuccess = ret.IsSuccess, Message = ret.GetErrors() });
            }
            catch(Exception ex)
            {
                return Json(new { IsSuccess=false,Message=ex.Message});
            }
        }
    }
}
