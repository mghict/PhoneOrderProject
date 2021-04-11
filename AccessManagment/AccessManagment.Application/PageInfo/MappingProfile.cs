using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile():base()
        {
            CreateMap<Commands.CreatePageInfoCommand,Domain.Entities.PageInfoTbl>();
            CreateMap<Domain.Entities.PageInfoTbl,Commands.CreatePageInfoCommand>();

            CreateMap<Commands.UpdatePageInfoCommand, Domain.Entities.PageInfoTbl>();
            CreateMap<Domain.Entities.PageInfoTbl, Commands.UpdatePageInfoCommand>();
        }
    }
}
