using System;
using System.Collections.Generic;


#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerInfoTbl")]
    public partial class CustomerInfoTbl : Models.Base.Entity
    {
        public CustomerInfoTbl()
        {
            CustomerAddressTbls = new HashSet<CustomerAddressTbl>();
            CustomerAttributeItemTbls = new HashSet<CustomerAttributeItemTbl>();
            CustomerOrderTbls = new HashSet<CustomerOrderTbl>();
            CustomerPhoneTbls = new HashSet<CustomerPhoneTbl>();
            CustomerPreOrderInfoTbls = new HashSet<CustomerPreOrderInfoTbl>();
        }

        public long Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public long WaletPrice { get; set; }
        public int Score { get; set; }
        public int RegisterTypeId { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan RegisterTime { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<CustomerAddressTbl> CustomerAddressTbls { get; set; }
        public virtual ICollection<CustomerAttributeItemTbl> CustomerAttributeItemTbls { get; set; }
        public virtual ICollection<CustomerOrderTbl> CustomerOrderTbls { get; set; }
        public virtual ICollection<CustomerPhoneTbl> CustomerPhoneTbls { get; set; }
        public virtual ICollection<CustomerPreOrderInfoTbl> CustomerPreOrderInfoTbls { get; set; }
    }
}
