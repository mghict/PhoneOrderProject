using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Reports
{
    public class GetSummeryOrdersByDateAndStore
    {
        public float StoreID { get; set; }
        public string StoreName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderSendTime { get; set; }
        public int OrderCount { get; set; }
    }
}
