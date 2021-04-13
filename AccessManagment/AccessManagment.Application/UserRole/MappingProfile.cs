using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserRole
{
    public class MappingProfile:
        AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.UserRoleAccessTbl, Commands.CreateUserRoleCommand>();
            CreateMap< Commands.CreateUserRoleCommand, Domain.Entities.UserRoleAccessTbl>();
        }
    }
}
