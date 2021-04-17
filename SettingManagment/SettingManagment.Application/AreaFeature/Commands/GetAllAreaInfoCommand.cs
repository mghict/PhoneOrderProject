using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.AreaInfoTbl>>
    {
    }
}
