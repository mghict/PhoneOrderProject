using System.Collections.Generic;

namespace AccessManagment.Application.RoleInfo.Commands
{
    public class GetRoleInfoByApplicationCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.RoleInfoTbl>>
    {
        public int ApplicationId { get; set; }

    }
}
