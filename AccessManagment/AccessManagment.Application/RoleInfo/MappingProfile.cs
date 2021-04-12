using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile():base()
        {
            CreateMap<Commands.CreateRoleInfoCommand,Domain.Entities.RoleInfoTbl>();
            CreateMap<Domain.Entities.RoleInfoTbl, Commands.CreateRoleInfoCommand>();

            CreateMap<Commands.UpdateRoleInfoCommand, Domain.Entities.RoleInfoTbl>();
            CreateMap<Domain.Entities.RoleInfoTbl, Commands.UpdateRoleInfoCommand>();
        }
    }
}
