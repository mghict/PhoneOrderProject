using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class StoreTimeSheet : AutoMapper.Profile
    {
        public StoreTimeSheet():base()
        {
            CreateMap<DTOs.Input.StoreTimeSheet.AddDto,Models.StoreTimeSheetTbl>();
            CreateMap<Models.StoreTimeSheetTbl, DTOs.Input.StoreTimeSheet.AddDto>();


            CreateMap<DTOs.Input.StoreTimeSheet.EditDto, Models.StoreTimeSheetTbl>();
            CreateMap<Models.StoreTimeSheetTbl, DTOs.Input.StoreTimeSheet.EditDto>();

            CreateMap<DTOs.Results.StoreTimeSheet.EntityDto, Models.StoreTimeSheetTbl>();
            CreateMap<Models.StoreTimeSheetTbl, DTOs.Results.StoreTimeSheet.EntityDto>();
        }
    }
}
