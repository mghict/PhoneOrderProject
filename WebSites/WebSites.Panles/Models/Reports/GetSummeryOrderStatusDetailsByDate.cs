using System;

namespace WebSites.Panles.Models.Reports
{
    public class GetSummeryOrderStatusDetailsByDate
    {
        public float StoreId { get; set; }
        public string StoreName { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusStr { get; set; }
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderCount { get; set; }
        public long TotalPrice { get; set; }
        public long ShippingPrice { get; set; }
        public long FinalPrice { get; set; }
    }
}
