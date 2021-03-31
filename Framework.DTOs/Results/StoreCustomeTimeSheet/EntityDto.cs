using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.StoreCustomeTimeSheet
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public double StoreId { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public short StepTime { get; set; }
        public byte Status { get; set; }

        public Results.Store.EntityDto Store { get; set; }
    }
}
