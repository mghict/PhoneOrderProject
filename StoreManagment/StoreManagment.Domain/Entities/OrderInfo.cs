using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System;

namespace StoreManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderInfoTbl")]
    public class OrderInfo:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }

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
        public long AddressId { get; set; }
        public float StoreId { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public int? ShippingPricePayment { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public List<OrderItems> Items { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public OrderInfoDetails Detail { get; set; }
    }
}
