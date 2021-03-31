using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Application.UserFeatures.Commands
{
    public class UserAccessCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public UserAccessCommand():base()
        {

        }

        public string Token { get; set; }
        public string MethodName { get; set; }
    }
}
