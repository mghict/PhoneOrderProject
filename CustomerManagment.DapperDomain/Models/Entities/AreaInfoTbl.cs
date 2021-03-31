using System.Collections.Generic;
using Dapper.Contrib.Extensions;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Table("AreaInfoTbl")]
    public partial class AreaInfoTbl : Models.Base.Entity
    {
        public AreaInfoTbl() : base()
        {
            AreaGeoTbls = new HashSet<AreaGeoTbl>();
            StoreAreaTbls = new HashSet<StoreAreaTbl>();
        }

        public int Id { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public int? ParentId { get; set; }
        public double CenterLatitude { get; set; }
        public double Centerlongitude { get; set; }
        public byte Status { get; set; }
        public int CityId { get; set; }

        public virtual CityTbl City { get; set; }
        public virtual ICollection<AreaGeoTbl> AreaGeoTbls { get; set; }
        public virtual ICollection<StoreAreaTbl> StoreAreaTbls { get; set; }
    }
}
