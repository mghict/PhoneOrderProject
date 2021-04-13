using System.Collections.Generic;

namespace AccessManagment.Application.User.Commands
{
    public class GetAllUserSearchCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserModel>
    {
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.UserInfoTbl>>
    {
    }

}
