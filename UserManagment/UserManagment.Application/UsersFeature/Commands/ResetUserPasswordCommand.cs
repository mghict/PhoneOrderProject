using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Application.UsersFeature.Commands
{
    public class ResetUserPasswordCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public string UserName  { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewRetPassword { get; set; }
    }
}
