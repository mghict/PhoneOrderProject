using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Order
{
    public class UserActivityOrderLogs
    {
        public long OrderCode { get; set; }
        public DateTime CreatDate { get; set; }
        public string Description { get; set; }
        public string FullDescr { get; set; }
    }
}
