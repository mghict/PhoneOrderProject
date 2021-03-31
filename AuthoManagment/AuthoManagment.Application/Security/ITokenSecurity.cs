using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthoManagment.Application.Security
{
    public interface ITokenSecurity
    {
        string GenerateJWTToken(AuthoManagment.Domain.Entities.UserInfoTbl userInfo);
        //int AccessInOperation(DTOs.Input.UserInfo.UserAccessDto userAccess);
    }
}
