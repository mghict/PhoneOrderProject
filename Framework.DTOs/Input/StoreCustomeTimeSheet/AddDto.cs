using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.StoreCustomeTimeSheet
{
    public class AddDto:Base.DtoInputBase
    {
        public double StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }
    }
}
