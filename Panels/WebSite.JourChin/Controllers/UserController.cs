using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebSite.JourChin.Helper;
using WebSite.JourChin;

namespace WebSite.JourChin.Controllers
{
    public class UserController : Base.BaseController
    {
        private readonly Services.User.IUserActivityService _userActivityService;
        public UserController(
            Services.User.IUserActivityService UserActivityService,
            ServiceCaller serviceCaller, ICachedMemoryService _cacheService, IMapper mapper) : base(serviceCaller, _cacheService, mapper)
        {
            _userActivityService = UserActivityService;
            
        }

        public async Task<IActionResult> Index()
        {
            Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
            if(user!=null)
            {
                var item = await _userActivityService.GetByUserIdCurrentDateAsync(user.UserId);
                
                return View(item);
            }
            else
            {
                return Redirect("/Home/AccessDenied");
            }
            
        }

        public async Task<IActionResult> SendRequest()
        {
            try
            {
                Models.UserModel user = HttpContext.Session.Get<Models.UserModel>("User");
                if (user != null)
                {
                    Models.User.UserActivityModel model = new Models.User.UserActivityModel()
                    {
                        CreateDate = System.DateTime.Now,
                        Status = 1,
                        UserId = user.UserId
                    };

                    var item = await _userActivityService.CreateAsync(model);

                    return Json(new { IsSuccess = item.IsSuccess, Message = item.Errors.Select(s => s.Message).ToList().ListToStringMessage() });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "دسترسی کاربر صحیح نمی باشد" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { IsSuccess = false, Message =  ex.Message  });
            }
        }
    }
}
