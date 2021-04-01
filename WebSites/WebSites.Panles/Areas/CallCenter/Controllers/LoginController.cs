using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
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

        private readonly ServiceCaller<Token> Service;
        public LoginController(IHttpClientFactory _clientFactory,
            Services.Authorize.IAuthorizeService authorizeService)
        {
            Service = new ServiceCaller<Token>(_clientFactory);
            AuthorizeService = authorizeService;
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
                //var result = Service.PostDataWithValue("login", model);
                //var ret = result.Result;
                //if (ret != null && ret.IsSuccess == true && ret.Value != null)
                //{
                //    BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token token =
                //        (BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token)ret.Value;
                //    Service.SetToken(token.TokenValue);
                //    ret.WithSuccess("ورود موفق");
                //}

                //return Json(ret);
                long uname = Convert.ToInt64(userName);
                var result=AuthorizeService.Login(uname, password, applicationId);

                return Json(new { IsSuccess = result.IsSuccess, Errors = result.GetErrors() });

            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Errors = "خطا \n" + ex.Message });

            }




        }
    }
}
