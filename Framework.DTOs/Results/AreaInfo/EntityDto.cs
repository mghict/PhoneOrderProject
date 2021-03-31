using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.AreaInfo
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public int? ParentId { get; set; }
        public double CenterLatitude { get; set; }
        public double Centerlongitude { get; set; }
        public byte Status { get; set; }
        public int CityId { get; set; }

        public IEnumerable<DTOs.Results.AreaGeo.EntityDto> AreaGeo { get; set; }
    }
}
