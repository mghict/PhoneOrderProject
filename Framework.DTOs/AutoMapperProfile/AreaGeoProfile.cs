using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class AreaGeoProfile:AutoMapper.Profile
    {
        public AreaGeoProfile()
        {
            CreateMap<DTOs.Input.AreaGeo.AddDto, Models.AreaGeoTbl>();
            CreateMap<DTOs.Input.AreaGeo.EditDto, Models.AreaGeoTbl>();
            CreateMap<DTOs.Results.AreaGeo.EntityDto, Models.AreaGeoTbl>();
            CreateMap<Models.AreaGeoTbl, DTOs.Results.AreaGeo.EntityDto>();
        }
    }
}
