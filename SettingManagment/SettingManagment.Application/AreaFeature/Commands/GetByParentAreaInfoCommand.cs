using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetByParentAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.AreaInfoTbl>>
    {
        public int ParentId { get; set; }
        public int AreaType { get; set; }
    }
}
