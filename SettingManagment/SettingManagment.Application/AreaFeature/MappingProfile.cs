using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Domain.Entities.AreaInfoTbl, Commands.CreateAreaInfoCommand>();
            CreateMap<Commands.CreateAreaInfoCommand, Domain.Entities.AreaInfoTbl>();

            CreateMap<Domain.Entities.AreaInfoTbl, Commands.UpdateAreaInfoCommand>();
            CreateMap<Commands.UpdateAreaInfoCommand, Domain.Entities.AreaInfoTbl>();
        }
    }
}
