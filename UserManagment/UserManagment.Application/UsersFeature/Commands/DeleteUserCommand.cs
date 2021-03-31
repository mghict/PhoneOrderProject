using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Application.UsersFeature.Commands
{
    public class DeleteUserCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
    }
}
