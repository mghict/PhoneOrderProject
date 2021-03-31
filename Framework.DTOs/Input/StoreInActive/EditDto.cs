using System;

namespace DTOs.Input.StoreInActive
{
    public class EditDto : Base.DtoInputBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public byte Status { get; set; }
    }
}
