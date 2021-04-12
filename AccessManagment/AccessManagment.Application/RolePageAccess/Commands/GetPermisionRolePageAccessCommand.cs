using System.Collections.Generic;

namespace AccessManagment.Application.RolePageAccess.Commands
{
    public class GetPermisionRolePageAccessCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.RolePagesAccess>>
    {
        public int RoleId { get; set; }
    }

}
