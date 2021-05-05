using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.Util;

namespace BillManagement.Domain.Entities
{
    public class OrderResponse
    {
        public long OrderCode { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public float StoreId { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public OrderResponse()
        {
            OrderCode = 0;
            CustomerName = "";
            OrderDate = DateTime.Now.ToPersianDate();
            StoreId = 0.0f;

            OrderItems = new List<OrderItems>();
        }

        public OrderResponse(long orderCode, string customerName, string orderDate, float storeId)
        {
            OrderCode = orderCode;
            CustomerName = customerName;
            OrderDate = orderDate;
            StoreId = storeId;

            OrderItems = new List<OrderItems>();
        }

        public OrderResponse(long orderCode, string customerName, string orderDate, float storeId, List<OrderItems> orderItems)
        {
            OrderCode = orderCode;
            CustomerName = customerName;
            OrderDate = orderDate;
            StoreId = storeId;
            OrderItems = orderItems;
        }
    }
}
