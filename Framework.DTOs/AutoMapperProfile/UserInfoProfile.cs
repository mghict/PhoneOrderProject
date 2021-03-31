using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AutoMapperProfile
{
    public class UserInfoProfile:AutoMapper.Profile
    {
        public UserInfoProfile():base()
        {
            //CreateMap<Models.UserInfoTbl, DTOs.Results.UserInfo.TokenDto>();
            //CreateMap<DTOs.Results.UserInfo.TokenDto, Models.UserInfoTbl>();

        }
    }
}
