namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AreaGeoTbl")]
    public class AreaGeoTbl:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int AreaId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool Status { get; set; }
    }

}
