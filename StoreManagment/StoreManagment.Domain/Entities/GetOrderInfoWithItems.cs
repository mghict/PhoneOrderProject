using System.Collections.Generic;

namespace StoreManagment.Domain.Entities
{
    public class GetOrderInfoWithItems
    {
        public GetOrderInfo OrderInfo { get; set; }
        public List<GetOrderItems> OrderItems { get; set; }
    }
}
