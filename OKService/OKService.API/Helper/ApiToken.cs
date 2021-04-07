using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKService.API
{
    public sealed class ApiToken
    {
        public Models.LoginResponseModel UserToken { get; set; }
        private ApiToken()
        {}

        private static ApiToken instance = null;
        public static ApiToken GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiToken();
                }
                return instance;
            }
        }

    }
}
