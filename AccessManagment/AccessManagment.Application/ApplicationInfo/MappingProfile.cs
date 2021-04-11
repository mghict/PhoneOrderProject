using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.Util.Security;

namespace AccessManagment.Application.ApplicationInfo
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() : base()
        {

            //CreateMap<Commands.UpdateApplicationInfoCommand, Domain.Entities.ApplicationInfoTbl>();
            //CreateMap<Domain.Entities.ApplicationInfoTbl, Commands.UpdateApplicationInfoCommand>();

        }
    }
}
