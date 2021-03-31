using System;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreTimeSheetTbl")]
    public partial class StoreTimeSheetTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public short FromDay { get; set; }
        public short ToDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }

        public virtual StoreInfoTbl Store { get; set; }
    }
}
