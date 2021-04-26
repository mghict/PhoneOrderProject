using System.Collections.Generic;

namespace AccessManagment.Application.User.Commands
{

    public class GetAllUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.UserInfoTbl>>
    {
    }

}
