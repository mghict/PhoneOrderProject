#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreAreaTbl")]
    public partial class StoreAreaTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public int AreaId { get; set; }
        public int ShippingPrice { get; set; }
        public byte DrivingTime { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }

        public virtual AreaInfoTbl Area { get; set; }
        public virtual StoreInfoTbl Store { get; set; }
    }
}
