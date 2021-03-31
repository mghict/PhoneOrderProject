using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class CategoryProfile:AutoMapper.Profile
    {
        public CategoryProfile():base()
        {
            CreateMap<DTOs.Input.Category.AddDto,Models.CategoryInfoTbl>();
            CreateMap<Models.CategoryInfoTbl, DTOs.Input.Category.AddDto>();


            CreateMap<DTOs.Input.Category.EditDto, Models.CategoryInfoTbl>();
            CreateMap<Models.CategoryInfoTbl, DTOs.Input.Category.EditDto>();

            CreateMap<DTOs.Results.Category.EntityDto, Models.CategoryInfoTbl>();
            CreateMap<Models.CategoryInfoTbl, DTOs.Results.Category.EntityDto>();
        }
    }
}
