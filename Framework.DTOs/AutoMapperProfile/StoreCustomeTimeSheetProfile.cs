using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class StoreCustomeTimeSheetProfile : AutoMapper.Profile
    {
        public StoreCustomeTimeSheetProfile():base()
        {
            CreateMap<DTOs.Input.StoreCustomeTimeSheet.AddDto,Models.StoreCustomeTimeSheetTbl>();
            CreateMap<Models.StoreCustomeTimeSheetTbl, DTOs.Input.StoreCustomeTimeSheet.AddDto>();


            CreateMap<DTOs.Input.StoreCustomeTimeSheet.EditDto, Models.StoreCustomeTimeSheetTbl>();
            CreateMap<Models.StoreCustomeTimeSheetTbl, DTOs.Input.StoreCustomeTimeSheet.EditDto>();

            CreateMap<DTOs.Results.StoreCustomeTimeSheet.EntityDto, Models.StoreCustomeTimeSheetTbl>();
            CreateMap<Models.StoreCustomeTimeSheetTbl, DTOs.Results.StoreCustomeTimeSheet.EntityDto>();
        }
    }
}
