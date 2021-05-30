namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreGeneralShippingByDistanceTbl")]
    public class StoreGeneralShippingByDistanceTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int FromDistance { get; set; }
        public int ToDistance { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
