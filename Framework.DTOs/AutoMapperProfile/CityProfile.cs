using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class CityProfile:AutoMapper.Profile
    {
        public CityProfile():base()
        {
            CreateMap<DTOs.Input.City.AddDto, Models.CityTbl>();
            CreateMap<DTOs.Input.City.EditDto, Models.CityTbl>();
            CreateMap<DTOs.Results.City.EntityDto, Models.CityTbl>();
            CreateMap<Models.CityTbl,DTOs.Results.City.EntityDto>();
        }
    }
}
