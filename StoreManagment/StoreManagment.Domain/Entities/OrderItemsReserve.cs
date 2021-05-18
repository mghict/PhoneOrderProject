using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderItemsReserveTbl")]
    public class OrderItemsReserve:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string ProductCode { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string DisplayName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string ProductName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string BrandName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string CategoryName { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public float? CategoryId { get; set; }
    }

}
