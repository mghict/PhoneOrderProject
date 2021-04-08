using System;

namespace SettingManagment.Domain.Entities
{
    public class StoreCustomeTimeSheetTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        public int Id { get; set; }
        public float StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public byte StepTime { get; set; }
        public bool Status { get; set; }
    }
}
