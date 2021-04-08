using System;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreTimeSheetTbl")]
    public class StoreTimeSheetTbl:
        BehsamFramework.Entity.IEntity<byte>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte FromDay { get; set; }
        public byte ToDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public byte StepTime { get; set; }
        public bool Status { get; set; }
    }
}
