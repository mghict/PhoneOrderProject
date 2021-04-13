using System.Collections.Generic;

namespace AccessManagment.Application.UserRole.Commands
{
    public class GetUserRoleByUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.UserRoleAccessTbl>>
    {
        public int UserId { get; set; }
    }
}
