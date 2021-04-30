using System.Collections.Generic;

namespace BillManagement.Domain.Entities
{
    public class OrderRequest
    {
        public long OrderCode { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
