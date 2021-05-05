using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.Application.BillFeature.Commands
{
    public class LoginUserCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
