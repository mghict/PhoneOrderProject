using Microsoft.Extensions.Configuration;
using OKService.API.Helper;
using OKService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKService.API.Services
{
    public interface ILoginService
    {
        Task ExecuteSingletonAsync();
        Task<Models.LoginResponseModel> ExecuteResponseAsync();
    }
    public class LoginService:ILoginService
    {
        private readonly Helper.ServiceCaller ServiceCaller;
        private readonly string UserName;
        private readonly string Password;

        public LoginService(ServiceCaller serviceCaller, IConfiguration configuration)
        {
            string userName =
                    configuration
                    .GetSection(key: "UserName")
                    .Value;

            string password =
                configuration
                .GetSection(key: "Password")
                .Value;

            ServiceCaller = serviceCaller;
            UserName=userName;
            Password = password;
        }

        public async Task<LoginResponseModel> ExecuteResponseAsync()
        {
            LoginResponseModel rest = new LoginResponseModel();

            var command = new
            {
                username = UserName,
                password = Password,
                ip = "",
                imei = ""
            };

            try
            {
                rest = await ServiceCaller.PostDataWithValue<Models.LoginResponseModel>("login", command);
            }
            catch
            {
                rest = new LoginResponseModel();
            }

            return rest;
            
        }
        public async Task ExecuteSingletonAsync()
        {

            var token = ApiToken.GetInstance;

            var command = new
            {
                username = UserName,
                password = Password,
                ip = "",
                imei = ""
            };

            var resp = await ServiceCaller.PostDataWithValue<Models.LoginResponseModel>("login", command);

            if(resp != null && !string.IsNullOrEmpty( resp.result))
            {
                token.UserToken = resp;
            }
        }

    }
}
