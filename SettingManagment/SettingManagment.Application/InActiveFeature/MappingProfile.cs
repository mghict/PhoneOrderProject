using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Domain.Entities.InActiveTbl, Commands.CreateInActiveCommand>();
            CreateMap<Commands.CreateInActiveCommand,Domain.Entities.InActiveTbl>();

            CreateMap<Domain.Entities.InActiveTbl, Commands.EditInActiveCommand>();
            CreateMap<Commands.EditInActiveCommand, Domain.Entities.InActiveTbl>();
        }
    }
}
