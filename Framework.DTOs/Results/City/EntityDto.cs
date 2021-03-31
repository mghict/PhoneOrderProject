using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.City
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public double CityId { get; set; }
        public string CityName { get; set; }
        public double ProvinceId { get; set; }

        public Results.Province.EntityDto Province { get; set; }
        public IEnumerable<DTOs.Results.AreaInfo.EntityDto> AreaInfo { get; set; }
    }
}
