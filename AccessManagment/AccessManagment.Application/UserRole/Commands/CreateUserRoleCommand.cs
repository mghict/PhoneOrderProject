using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserRole.Commands
{
    public class CreateUserRoleCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
}
