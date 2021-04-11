using System.Collections.Generic;

namespace AccessManagment.Application.PageInfo.Commands
{
    public class GetByParentPageInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.PageInfoTbl>>
    {
        public int ParentId { get; set; }
    }
}
