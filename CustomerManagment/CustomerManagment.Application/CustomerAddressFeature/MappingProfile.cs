using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerAddressFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Commands.CreateCustomerAddressCommand, Domain.Entities.CustomerAddressTbl>();
            CreateMap<Domain.Entities.CustomerInfoTbl,Commands.CreateCustomerAddressCommand>();

            CreateMap<Commands.UpdateCustomerAddressCommand, Domain.Entities.CustomerAddressTbl>();
            CreateMap<Domain.Entities.CustomerAddressTbl, Commands.UpdateCustomerAddressCommand>();

            CreateMap<BehsamFramework.Models.CustomerAddressModel, Domain.Entities.CustomerAddressTbl>();
            CreateMap<Domain.Entities.CustomerAddressTbl, BehsamFramework.Models.CustomerAddressModel>();

        }
    }
}
