using System;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreInActiveTbl")]
    public partial class StoreInActiveTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public byte Status { get; set; }

        public virtual StoreInfoTbl Store { get; set; }
    }
}
