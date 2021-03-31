using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class StoreInActiveProfile:AutoMapper.Profile
    {
        public StoreInActiveProfile():base()
        {
            CreateMap<DTOs.Input.StoreInActive.AddDto,Models.StoreInActiveTbl>();
            CreateMap<Models.StoreInActiveTbl, DTOs.Input.StoreInActive.AddDto>();


            CreateMap<DTOs.Input.StoreInActive.EditDto, Models.StoreInActiveTbl>();
            CreateMap<Models.StoreInActiveTbl, DTOs.Input.StoreInActive.EditDto>();

            CreateMap<DTOs.Results.StoreInActive.EntityDto, Models.StoreInActiveTbl>();
            CreateMap<Models.StoreInActiveTbl, DTOs.Results.StoreInActive.EntityDto>();
        }
    }
}
