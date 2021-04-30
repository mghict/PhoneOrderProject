namespace BillManagement.Domain.Entities
{
    public class OrderItems
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int Status { get; set; }
    }
}
