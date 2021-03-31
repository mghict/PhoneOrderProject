namespace DTOs.Input.Product
{
    public class EditDto : Base.DtoInputBase
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public double CategotyId { get; set; }
        public string BrandName { get; set; }
        public double UnitPrice { get; set; }
        public byte TaxPrice { get; set; }
        public int MeasureType { get; set; }
        public string ImageUrl { get; set; }
        public byte Status { get; set; }
    }
}


