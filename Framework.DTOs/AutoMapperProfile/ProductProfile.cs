using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile():base()
        {
            CreateMap<DTOs.Input.Product.AddDto,Models.ProductInfoTbl>();
            CreateMap<Models.ProductInfoTbl, DTOs.Input.Product.AddDto>();


            CreateMap<DTOs.Input.Product.EditDto, Models.ProductInfoTbl>();
            CreateMap<Models.ProductInfoTbl, DTOs.Input.Product.EditDto>();

            CreateMap<DTOs.Results.Product.EntityDto, Models.ProductInfoTbl>();
            CreateMap<Models.ProductInfoTbl, DTOs.Results.Product.EntityDto>();
        }
    }
}
