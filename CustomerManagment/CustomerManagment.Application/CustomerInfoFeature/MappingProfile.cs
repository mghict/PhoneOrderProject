using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerInfoFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Commands.CreateCustomerCommand,Domain.Entities.CustomerInfoTbl>()
                .ForMember(dest => dest.RegisterDate,
                    opts => opts.MapFrom(source => System.DateTime.Now))
                .ForMember(dest => dest.RegisterTime,
                    opts => opts.MapFrom(source => System.DateTime.Now.TimeOfDay));
            CreateMap<Domain.Entities.CustomerInfoTbl,Commands.CreateCustomerCommand>();

            CreateMap<Commands.UpdateCustomerCommand,Domain.Entities.CustomerInfoTbl>();
            CreateMap<Domain.Entities.CustomerInfoTbl,Commands.UpdateCustomerCommand>();


            CreateMap<BehsamFramework.Models.CustomerGetByIdDataModel, CustomerManagment.Domain.Entities.CustomerInfoTbl>();
            CreateMap<CustomerManagment.Domain.Entities.CustomerInfoTbl,BehsamFramework.Models.CustomerGetByIdDataModel>();


            CreateMap<BehsamFramework.Models.CustomerInfoModel, CustomerManagment.Domain.Entities.CustomerInfoTbl>();
            CreateMap<CustomerManagment.Domain.Entities.CustomerInfoTbl,BehsamFramework.Models.CustomerInfoModel >();
        }
    }
}
