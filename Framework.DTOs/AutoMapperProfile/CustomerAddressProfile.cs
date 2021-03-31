using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    class CustomerAddressProfile : AutoMapper.Profile
    {
        public CustomerAddressProfile() : base()
        {
            CreateMap<DTOs.Input.AddressDto.AddDto, Models.CustomerAddressTbl>();
            CreateMap<DTOs.Input.AddressDto.EditDto, Models.CustomerAddressTbl>();
            CreateMap<Models.CustomerAddressTbl, DTOs.Results.CustomerAddress.EntityDto>();
        }
    }
}
