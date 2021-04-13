using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.Commands
{
    public class CreateUserCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public float Storeid { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }

}
