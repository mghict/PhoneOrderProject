using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Authorize
{
    public class UserModel
    {
        public long RowCount { get; set; }
        public List<UserInfo> Users { get; set; }
    }
}
