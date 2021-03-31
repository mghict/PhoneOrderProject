#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("AreaGeoTbl")]
    public partial class AreaGeoTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte Status { get; set; }

        public virtual AreaInfoTbl Area { get; set; }
    }
}
