using System.Collections.Generic;

namespace AccessManagment.Application.PageInfo.Commands
{
    public class GetByApplicationPageInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.PageInfoTbl>>
    {
        public int ApplicationId { get; set; }
    }
}
