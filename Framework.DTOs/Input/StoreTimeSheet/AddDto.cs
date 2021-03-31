using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.StoreTimeSheet
{
    public class AddDto:Base.DtoInputBase
    {
        public double StoreId { get; set; }
        public short FromDay { get; set; }
        public short ToDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }
    }
}
