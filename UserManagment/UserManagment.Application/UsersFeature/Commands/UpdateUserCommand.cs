using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Application.UsersFeature.Commands
{
    public class UpdateUserCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public byte Status { get; set; }
        public string UserName { get; set; }
    }
}
