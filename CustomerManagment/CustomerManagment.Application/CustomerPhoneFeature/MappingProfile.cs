using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerPhoneFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile():base()
        {
            CreateMap<Commands.CreateCustomerPhoneCommand, Domain.Entities.CustomerPhoneTbl>();
            CreateMap<Domain.Entities.CustomerPhoneTbl,Commands.CreateCustomerPhoneCommand>();

            CreateMap<Commands.CreateCustomerPhoneWithListCommand, Domain.Entities.CustomerPhoneTbl>();
            CreateMap<Domain.Entities.CustomerPhoneTbl, Commands.CreateCustomerPhoneWithListCommand>();

            CreateMap<Commands.UpdateCustomerPhoneCommand, Domain.Entities.CustomerPhoneTbl>();
            CreateMap<Domain.Entities.CustomerPhoneTbl, Commands.UpdateCustomerPhoneCommand>();

            CreateMap<BehsamFramework.Models.CustomerPhoneModel, Domain.Entities.CustomerPhoneTbl>();
            CreateMap<Domain.Entities.CustomerPhoneTbl, BehsamFramework.Models.CustomerPhoneModel>();
        }
    }
}
