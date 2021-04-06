using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagment.Domain.Entities
{
    public class GetOrderDetailsByUserId:
        BehsamFramework.Entity.IEntity<long>
    {
        public long OrderCode { get; set; }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public long TotalPrice { get; set; }
        public long DiscountPrice { get; set; }
        public long TaxPrice { get; set; }
        public long ShippingPrice { get; set; }
        public long FinalPrice { get; set; }
        public int OrderState { get; set; }
        public string OrderStateStr { get; set; }
        public long AddressID { get; set; }
        public string AddressValue { get; set; }
        public float StoreId { get; set; }
        public string StoreName { get; set; }
        public int OrderCount { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
