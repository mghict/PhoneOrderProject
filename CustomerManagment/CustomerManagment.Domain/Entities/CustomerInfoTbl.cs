using System;
using System.Collections.Generic;


#nullable disable

namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerInfoTbl")]
    public partial class CustomerInfoTbl : BehsamFramework.Entity.IEntity<long>
    {

        public long Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public long WaletPrice { get; set; }
        public int Score { get; set; }
        public int RegisterTypeId { get; set; }
        public int Sex { get; set; }
        public int Job { get; set; }
        public int Education { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan RegisterTime { get; set; }
        public byte Status { get; set; }
        public long DefaultMobile { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string CustomerFullName {
            get
            {
                return string.Concat(CustomerName, " ", CustomerLastName);
            }
        }
    }
}
