using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllProvinceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.ProvinceTbl>>
    {
    }
}
