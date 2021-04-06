using System;

namespace StoreManagment.Domain.Entities
{
    public class GetSummeryOrderStatusByDate :
        BehsamFramework.Entity.IEntity<float>
    {
        public float StoreId { get; set; }
        public string StoreName { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusStr { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderCount { get; set; }
        public long TotalPrice { get; set; }
        public long ShippingPrice { get; set; }
        public long FinalPrice { get; set; }
    }
}
