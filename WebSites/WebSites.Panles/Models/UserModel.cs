using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string  StoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ApplicationId { get; set; }
        public string Token { get; set; }
        public string UserIp { get; set; }
    }
}
