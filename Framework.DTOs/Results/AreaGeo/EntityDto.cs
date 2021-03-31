using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.AreaGeo
{
    public class EntityDto:DTOs.Base.DtoResultBase
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte Status { get; set; }

        public DTOs.Results.AreaInfo.EntityDto AreaInfo { get; set; }
    }
}
