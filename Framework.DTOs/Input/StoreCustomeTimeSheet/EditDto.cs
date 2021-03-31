using System;

namespace DTOs.Input.StoreCustomeTimeSheet
{
    public class EditDto : Base.DtoInputBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }
    }
}
