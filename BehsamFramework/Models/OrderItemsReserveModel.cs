using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class OrderItemsReserveModel 
    {
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }

        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public float? CategoryId { get; set; }
    }
}
