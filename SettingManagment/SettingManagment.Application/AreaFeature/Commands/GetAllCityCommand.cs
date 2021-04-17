using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllCityCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CityTbl>>
    {
    }
}
