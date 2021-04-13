using System.Collections.Generic;

namespace AccessManagment.Application.UserRole.Commands
{
    public class GetUserRoleByRoleCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.UserRoleAccessTbl>>
    {
        public int RoleId { get; set; }
    }
}
