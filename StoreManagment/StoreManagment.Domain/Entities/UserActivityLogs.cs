using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.Entities
{
    public class UserActivityLogs
    {
        public long OrderCode { get; set; }
        public DateTime CreatDate { get; set; }
        public string Description { get; set; }
        public string FullDescr { get; set; }
    }
}
