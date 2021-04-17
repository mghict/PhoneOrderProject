using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllAreaTypeCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.AttributeStatus>>
    {
    }
}
