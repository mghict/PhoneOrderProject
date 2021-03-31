using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CityTbl")]
    public partial class CityTbl : Models.Base.Entity
    {
        public CityTbl()
        {
            AreaInfoTbls = new HashSet<AreaInfoTbl>();
        }

        public int Id { get; set; }
        public double CityId { get; set; }
        public string CityName { get; set; }
        public double ProvinceId { get; set; }

        public virtual ProvinceTbl Province { get; set; }
        public virtual ICollection<AreaInfoTbl> AreaInfoTbls { get; set; }
    }
}
