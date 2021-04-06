using System.Collections.Generic;

namespace WebSites.Panles.Models.Reports
{
    public class GetOrderInfoWithItems
    {
        public GetOrderInfo OrderInfo { get; set; }
        public List<GetOrderItems> OrderItems { get; set; }
    }
}
