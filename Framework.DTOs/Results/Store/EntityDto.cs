using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.Store
{
    public class EntityDto:Base.DtoResultBase
    {
        public double StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }

        /*public virtual ICollection<StoreAreaTbl> StoreAreaTbls { get; set; }
        public virtual ICollection<StoreCustomeTimeSheetTbl> StoreCustomeTimeSheetTbls { get; set; }
        public virtual ICollection<StoreInActiveTbl> StoreInActiveTbls { get; set; }
        public virtual ICollection<StoreProductTbl> StoreProductTbls { get; set; }
        public virtual ICollection<StoreTimeSheetTbl> StoreTimeSheetTbls { get; set; }*/
    }
}
