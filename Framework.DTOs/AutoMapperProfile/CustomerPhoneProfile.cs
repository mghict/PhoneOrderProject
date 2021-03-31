using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class CustomerPhoneProfile:AutoMapper.Profile
    {
        public CustomerPhoneProfile():base()
        {
            CreateMap<DTOs.Input.PhoneDto.AddDto, Models.CustomerPhoneTbl>();
            CreateMap<DTOs.Input.PhoneDto.EditDto, Models.CustomerPhoneTbl>();

            CreateMap<DTOs.Results.CustomerPhone.EntityDto, Models.CustomerPhoneTbl>();
            CreateMap<Models.CustomerPhoneTbl,DTOs.Results.CustomerPhone.EntityDto>();
        }
    }
}
