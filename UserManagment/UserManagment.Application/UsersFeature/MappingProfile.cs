using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.Util.Security;

namespace UserManagment.Application.UsersFeature
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() : base()
        {
            BehsamFramework.Util.Security.SecurePasswordHasherHelper helper =
                new SecurePasswordHasherHelper();

            CreateMap<Commands.CreateUserCommand, Domain.Entities.UserInfoTbl>()
                .ForMember(dest=>dest.RegisterDate,
                    opts => opts.MapFrom(source => System.DateTime.Now))
                .ForMember(dest=>dest.Status,
                    opts=>opts.MapFrom(src=>1))
                .ForMember(dest=>dest.Password,
                    opts=>opts.MapFrom(src=>helper.Hash(src.Password)));
            CreateMap<Domain.Entities.UserInfoTbl, Commands.CreateUserCommand>();


            CreateMap<Commands.UpdateUserCommand, Domain.Entities.UserInfoTbl>();
            CreateMap<Domain.Entities.UserInfoTbl, Commands.UpdateUserCommand>();



            CreateMap<Commands.ResetUserPasswordCommand,Domain.Entities.UserInfoTbl>()
                .ForMember(dest=>dest.Password,
                    opts=>opts.MapFrom(src=>helper.Hash(src.CurrentPassword)));

            CreateMap<Commands.ResetAdminPasswordCommand, Domain.Entities.UserInfoTbl>()
                .ForMember(dest => dest.Password,
                    opts => opts.MapFrom(src => helper.Hash(src.NewPassword)));
        }
    }
}
