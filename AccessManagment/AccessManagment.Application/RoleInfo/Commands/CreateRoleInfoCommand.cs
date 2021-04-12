using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.Commands
{
    public class CreateRoleInfoCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        public bool Status { get; set; }

    }
}
