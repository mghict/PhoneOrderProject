using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Application.UsersFeature.Commands
{
    public class CreateUserCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string UserName { get; set; }
    }
}
