using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature
{
    public class MapperProfile:AutoMapper.Profile
    {
        public MapperProfile():base()
        {
            CreateMap<Commands.CreateUserActiveCommand,Domain.Entities.CustomerPreOrderUserActive>();
            CreateMap<Domain.Entities.CustomerPreOrderUserActive,Commands.CreateUserActiveCommand>();

            CreateMap<Commands.UpdateUserActiveCommand, Domain.Entities.CustomerPreOrderUserActive>();
            CreateMap<Domain.Entities.CustomerPreOrderUserActive, Commands.UpdateUserActiveCommand>();

            CreateMap<Commands.DeleteUserActiveCommand, Domain.Entities.CustomerPreOrderUserActive>();
            CreateMap<Domain.Entities.CustomerPreOrderUserActive, Commands.DeleteUserActiveCommand>();
        }
    }
}
