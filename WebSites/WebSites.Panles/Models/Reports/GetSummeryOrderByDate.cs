using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Reports
{
    public class GetSummeryOrderByDate
    {
        public float StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderCount { get; set; }
        public long TotalPrice { get; set; }
        public long ShippingPrice { get; set; }
        public long FinalPrice { get; set; }
    }
}
