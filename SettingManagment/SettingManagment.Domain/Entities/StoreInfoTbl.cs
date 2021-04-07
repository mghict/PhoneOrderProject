namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreInfoTbl")]
    public class StoreInfoTbl : BehsamFramework.Entity.IEntity<float>
    {
        [Dapper.Contrib.Extensions.Key]
        public float StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int AreaID { get; set; }
        public int Status { get; set; }
    }
}
