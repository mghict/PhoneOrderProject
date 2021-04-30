using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserActive
{
    public class MappingProfile:
        AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.UserActiveInfo, Commands.CreateUserActiveCommands>();
            CreateMap< Commands.CreateUserActiveCommands, Domain.Entities.UserActiveInfo>();


            CreateMap<Domain.Entities.UserActiveInfo, Commands.UpdateUserActiveCommands>();
            CreateMap<Commands.UpdateUserActiveCommands, Domain.Entities.UserActiveInfo>();

            CreateMap<Domain.Entities.UserActiveInfo, Commands.UpdateUserActiveStatusCommands>();
            CreateMap<Commands.UpdateUserActiveStatusCommands, Domain.Entities.UserActiveInfo>();
        }
    }
}
