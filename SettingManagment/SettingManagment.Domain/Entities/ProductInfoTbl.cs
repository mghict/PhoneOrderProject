namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("ProductInfoTbl")]
    public class ProductInfoTbl : BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public float CategotyID { get; set; }
        public string BrandName { get; set; }
        public float UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int MeasureType { get; set; }
        public byte Status { get; set; }
    }
}
