using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        class modelLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public long ApplicationId { get; set; }
        }

        private readonly ServiceCaller<BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token> Service;
        public HomeController(IHttpClientFactory _clientFactory)
        {
            Service = new ServiceCaller<Token>(_clientFactory);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet( Name = "AdminPanel")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        //[HttpPost("LoginAsync")]
        //public async Task<IActionResult> LoginAsync(string userName, string password)
        //{
        //    long applicationId = 1;
        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return Json(new { IsSuccess = "False", Errors = "اطلاعات وارد شده صحیح نمی باشد" });
        //        });

        //    }

        //    var model = new modelLogin()
        //    {
        //        UserName = userName,
        //        Password = password,
        //        ApplicationId = applicationId
        //    };
        //    try
        //    {
        //        var result = await Service.PostData("login", model);

        //        return await Task.Run(() =>
        //        {
        //            return Json(result);
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return Json(new { IsSuccess = "False", Errors = "خطا \n" + ex.Message });
        //        });
        //    }




        //}

        //[HttpPost("Login")]

        [HttpPost(Name = "Login")]
        public IActionResult Login(string userName, string password)
        {
            long applicationId = 1;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Json(new { IsSuccess = "False", Errors = "اطلاعات وارد شده صحیح نمی باشد" });
            }

            var model = new modelLogin()
            {
                UserName = userName,
                Password = password,
                ApplicationId = applicationId
            };
            try
            {
                var result = Service.PostDataWithValue("login", model);
                var ret = result.Result;
                if (ret!=null && ret.IsSuccess==true && ret.Value!=null)
                {
                    BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token token =
                        (BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token) ret.Value;
                    Service.SetToken(token.TokenValue);
                    ret.WithSuccess("ورود موفق");
                }

                return Json(ret);

            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = "False", Errors = "خطا \n" + ex.Message });

            }




        }
    }
}
