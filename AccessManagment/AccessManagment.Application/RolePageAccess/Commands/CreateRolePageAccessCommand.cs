using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.RolePageAccess.Commands
{
    public class CreateRolePageAccessCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public List<Domain.Entities.RolePagesAccess> Permision { get; set; }
    }

}
