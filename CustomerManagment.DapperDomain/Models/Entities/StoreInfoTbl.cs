using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreInfoTbl")]
    public partial class StoreInfoTbl : Models.Base.Entity
    {
        public StoreInfoTbl()
        {
            StoreAreaTbls = new HashSet<StoreAreaTbl>();
            StoreCustomeTimeSheetTbls = new HashSet<StoreCustomeTimeSheetTbl>();
            StoreInActiveTbls = new HashSet<StoreInActiveTbl>();
            StoreProductTbls = new HashSet<StoreProductTbl>();
            StoreTimeSheetTbls = new HashSet<StoreTimeSheetTbl>();
        }

        [Key]
        public double StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<StoreAreaTbl> StoreAreaTbls { get; set; }
        public virtual ICollection<StoreCustomeTimeSheetTbl> StoreCustomeTimeSheetTbls { get; set; }
        public virtual ICollection<StoreInActiveTbl> StoreInActiveTbls { get; set; }
        public virtual ICollection<StoreProductTbl> StoreProductTbls { get; set; }
        public virtual ICollection<StoreTimeSheetTbl> StoreTimeSheetTbls { get; set; }
    }
}
