using System;
using System.Collections.Generic;

namespace WebSites.Panles.Models.Order
{
    public class CachedOrderInfo
    {
        public long Id { get; set; } = 0;
        public long OrderCode { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int TaxPrice { get; set; }
        public int ShippingPrice { get; set; }
        public int FinalPrice { get; set; }
        public int OrderState { get; set; }
        public int PaymentType { get; set; }
        public long AddressID { get; set; }
        public float StoreID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ShippingPricePayment { get; set; }
        public List<CachedOrderItem> Items { get; set; }
    }
}
