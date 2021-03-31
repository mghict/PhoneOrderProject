using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Application.UserFeatures.Commands
{
    public class UserLoginCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.LoginModel>
    {
        public long UserName { get; set; }
        public string Password { get; set; }
        public int ApplicationId { get; set; }
    }
}
