using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class StoreProductProfile:AutoMapper.Profile
    {
        public StoreProductProfile():base()
        {
            CreateMap<DTOs.Input.StoreProduct.AddDto,Models.StoreProductTbl>();
            CreateMap<Models.StoreProductTbl, DTOs.Input.StoreProduct.AddDto>();


            CreateMap<DTOs.Input.StoreProduct.EditDto, Models.StoreProductTbl>();
            CreateMap<Models.StoreProductTbl, DTOs.Input.StoreProduct.EditDto>();

            CreateMap<DTOs.Results.StoreProduct.EntityDto, Models.StoreProductTbl>();
            CreateMap<Models.StoreProductTbl, DTOs.Results.StoreProduct.EntityDto>();
        }
    }
}
