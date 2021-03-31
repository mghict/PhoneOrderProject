using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.Store
{
    public class AddDto:Base.DtoInputBase
    {
        public double StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }
    }
}
