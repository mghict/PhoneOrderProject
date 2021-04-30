using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.Domain.Entities
{
    public class OrderResponse
    {
        public long OrderCode { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public float StoreId { get; set; }
        public List<OrderItems>? OrderItems { get; set; }
    }
}
