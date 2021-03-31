using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class ProvinceProfile:AutoMapper.Profile
    {
        public ProvinceProfile():base()
        {
            CreateMap<DTOs.Input.StoreInActive.AddDto,Models.ProvinceTbl>();
            CreateMap<Models.ProvinceTbl,DTOs.Input.StoreInActive.AddDto>();


            CreateMap<DTOs.Input.StoreInActive.EditDto, Models.ProvinceTbl>();
            CreateMap<Models.ProvinceTbl, DTOs.Input.StoreInActive.EditDto>();

            CreateMap<DTOs.Results.Province.EntityDto, Models.ProvinceTbl>();
            CreateMap<Models.ProvinceTbl, DTOs.Results.Province.EntityDto>();
        }
    }
}
