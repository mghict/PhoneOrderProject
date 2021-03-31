using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.AreaGeo
{
    public class AddDto:DTOs.Base.DtoInputBase
    {
        public int AreaId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte Status { get; set; }
    }
}
