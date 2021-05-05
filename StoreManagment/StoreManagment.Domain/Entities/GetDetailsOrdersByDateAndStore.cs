using System;

namespace StoreManagment.Domain.Entities
{
    public class GetDetailsOrdersByDateAndStore
    {
        public long Id { get; set; }
        public float StoreID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderSendTime { get; set; }
        public long OrderCode { get; set; }
        public TimeSpan OrderTime { get; set; }
        public string StatusDescription { get; set; }
    }
}
