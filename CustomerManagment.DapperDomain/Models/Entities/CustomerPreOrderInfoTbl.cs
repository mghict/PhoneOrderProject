using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderInfoTbl")]
    public partial class CustomerPreOrderInfoTbl : Models.Base.Entity
    {
        public CustomerPreOrderInfoTbl()
        {
            CustomerPreOrderItemsTbls = new HashSet<CustomerPreOrderItemsTbl>();
        }

        public int Id { get; set; }
        public string OrderCode { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int TaxPrice { get; set; }
        public int ShippingPrice { get; set; }
        public int FinalPrice { get; set; }
        public byte OrderState { get; set; }
        public int PaymentType { get; set; }
        public int AddressId { get; set; }
        public double StoreId { get; set; }

        public virtual CustomerInfoTbl Customer { get; set; }
        public virtual ICollection<CustomerPreOrderItemsTbl> CustomerPreOrderItemsTbls { get; set; }
    }
}
