using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Safir.Models
{
    public class LoginUserModel
    {
        public int UserId { get; set; }
        public string StoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ApplicationId { get; set; }
        public string Token { get; set; }
        public string UserIp { get; set; }

        public LoginUserModel()
        {
            UserIp = PhoneNumber = Name = StoreId = string.Empty;
            UserId = ApplicationId = 0;
        }
    }
}
