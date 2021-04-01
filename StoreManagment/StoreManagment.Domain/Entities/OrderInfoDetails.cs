using System;

namespace StoreManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderInfoDetails")]
    public class OrderInfoDetails:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int UserId { get; set; }
        public float? UserStoreId { get; set; }


        [Dapper.Contrib.Extensions.Write(false)]
        public OrderInfo Order { get; set; }
    }
}
