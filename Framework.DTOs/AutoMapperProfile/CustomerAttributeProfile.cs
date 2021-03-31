using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class CustomerAttributeProfile:AutoMapper.Profile
    {
        public CustomerAttributeProfile():base()
        {
            CreateMap<DTOs.Input.CustomerAttributes.AddDto, Models.CustomerAttributeTbl>();
            CreateMap<DTOs.Input.CustomerAttributes.EditDto, Models.CustomerAttributeTbl>();
            CreateMap<Models.CustomerAttributeTbl,DTOs.Results.CustomerAttribute.EntityDto>();
        }
    }
}
