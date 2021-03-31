using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.StoreArea
{
    public class AddDto:Base.DtoInputBase
    {
        public double StoreId { get; set; }
        public int AreaId { get; set; }
        public int ShippingPrice { get; set; }
        public byte DrivingTime { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }
    }
}
