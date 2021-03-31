using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.PanelAPI.Security
{
    public interface ITokenSecurity
    {
        Task AttachUserToContextByToken(HttpContext context, string token);
        //int AccessInOperation(DTOs.Input.UserInfo.UserAccessDto userAccess);
    }
}
