using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.JourChin.Models.Order
{
    public class GetOrderInfoWithItems
    {
        public GetOrderInfo OrderInfo { get; set; }
        public List<GetOrderItems> OrderItems { get; set; }
    }
}
