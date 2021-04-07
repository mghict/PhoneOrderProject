using OKService.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKService.API.Services
{
    public class StoreService
    {
        private readonly Helper.ServiceCaller ServiceCaller;
        private readonly Services.ILoginService LoginService;
        private ApiToken Token;

        public StoreService(ServiceCaller serviceCaller, ILoginService loginService)
        {
            ServiceCaller = serviceCaller;
            LoginService = loginService;
            Token = ApiToken.GetInstance;
        }

        public async Task<Models.GenericResponseModel<List<Models.StoreResponseModel>>> Execute()
        {
            var token = await LoginService.ExecuteResponseAsync();
            if (token != null && string.IsNullOrEmpty(token.result))
            {
                var command = new
                {
                    objectName = "WebsiteStores",
                    token = token.result,
                    ip = "",
                    imei = "",
                    param = ""
                };

                var result = await ServiceCaller.PostDataWithValue<Models.GenericResponseModel<List<Models.StoreResponseModel>>>("get", command);
                return result;
            }
            else
            {
                return new Models.GenericResponseModel<List<Models.StoreResponseModel>>();
            }
        }
    }
}
