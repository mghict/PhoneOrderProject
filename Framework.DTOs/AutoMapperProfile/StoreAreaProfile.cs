using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class StoreAreaProfile : AutoMapper.Profile
    {
        public StoreAreaProfile():base()
        {
            CreateMap<DTOs.Input.StoreArea.AddDto,Models.StoreAreaTbl>();
            CreateMap<Models.StoreAreaTbl, DTOs.Input.StoreArea.AddDto>();


            CreateMap<DTOs.Input.StoreArea.EditDto, Models.StoreAreaTbl>();
            CreateMap<Models.StoreAreaTbl, DTOs.Input.StoreArea.EditDto>();

            CreateMap<DTOs.Results.StoreArea.EntityDto, Models.StoreAreaTbl>();
            CreateMap<Models.StoreAreaTbl, DTOs.Results.StoreArea.EntityDto>();
        }
    }
}
