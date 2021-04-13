using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Authorize
{
    public class UserRoleModel
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string ApplicationName { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
