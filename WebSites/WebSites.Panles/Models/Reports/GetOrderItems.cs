namespace WebSites.Panles.Models.Reports
{
    public class GetOrderItems
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string BrandName { get; set; }
        public string DisplayName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string StatusName { get; set; }
    }
}
