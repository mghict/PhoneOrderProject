using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoManagment.Application.LoginFeature.Command
{
    public class LoginCommand:
        BehsamFramework.Mediator.CommandWithReturnValue
        <BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long ApplicationId { get; set; }
    }
}
