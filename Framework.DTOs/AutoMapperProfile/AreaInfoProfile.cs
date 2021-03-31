using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class AreaInfoProfile:AutoMapper.Profile
    {
        public AreaInfoProfile():base()
        {
            CreateMap<Models.AreaInfoTbl, DTOs.Results.AreaInfo.EntityDto>();
            CreateMap<DTOs.Results.AreaInfo.EntityDto,Models.AreaInfoTbl>();

        }
    }
}
