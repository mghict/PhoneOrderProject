using System;

namespace DTOs.Input.StoreTimeSheet
{
    public class EditDto : Base.DtoInputBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public short FromDay { get; set; }
        public short ToDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }
    }
}
