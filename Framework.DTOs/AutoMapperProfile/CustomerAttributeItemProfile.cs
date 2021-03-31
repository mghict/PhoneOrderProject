using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class CustomerAttributeItemProfile:AutoMapper.Profile
    {
        public CustomerAttributeItemProfile():base()
        {
            CreateMap<DTOs.Input.CustomerAttributeItem.AddDto, Models.CustomerAttributeItemTbl>();
            CreateMap<DTOs.Input.CustomerAttributeItem.EditDto, Models.CustomerAttributeItemTbl>();
            CreateMap<Models.CustomerAttributeItemTbl,DTOs.Results.CustomerAttributeItem.EntityDto>();
        }
    }
}
