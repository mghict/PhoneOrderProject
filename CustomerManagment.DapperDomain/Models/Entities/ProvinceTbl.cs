using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("ProvinceTbl")]
    public partial class ProvinceTbl : Models.Base.Entity
    {
        public ProvinceTbl()
        {
            CityTbls = new HashSet<CityTbl>();
        }

        public double Id { get; set; }
        public string ProvinceName { get; set; }

        public virtual ICollection<CityTbl> CityTbls { get; set; }
    }
}
