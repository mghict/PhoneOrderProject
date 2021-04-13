using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.User
{
    public class MappingProfile:
        AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.UserInfoTbl, Commands.CreateUserCommand>();
            CreateMap< Commands.CreateUserCommand, Domain.Entities.UserInfoTbl>();
        }
    }
}
