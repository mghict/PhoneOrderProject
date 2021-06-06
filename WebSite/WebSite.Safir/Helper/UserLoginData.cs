using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Safir.Models;

namespace WebSite.Safir.Helper
{
    public class UserLoginData
    {
        public Models.LoginUserModel UserData { get; set; }
        public UserLoginData()
        {
            UserData = new Models.LoginUserModel();
        }

        public UserLoginData(LoginUserModel userData)
        {
            UserData = userData;
        }
    }
}
