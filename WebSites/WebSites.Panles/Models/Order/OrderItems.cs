namespace WebSites.Panles.Models.Order
{
    [Dapper.Contrib.Extensions.Table("CustomerPreOrderItemsTbl")]
    public class OrderItems:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }



        [Dapper.Contrib.Extensions.Write(false)]
        public OrderInfo Order { get; set; }
    }
}
