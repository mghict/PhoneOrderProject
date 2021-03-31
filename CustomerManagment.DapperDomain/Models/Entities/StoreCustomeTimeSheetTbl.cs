using System;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreCustomeTimeSheetTbl")]
    public partial class StoreCustomeTimeSheetTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }

        public virtual StoreInfoTbl Store { get; set; }
    }
}
