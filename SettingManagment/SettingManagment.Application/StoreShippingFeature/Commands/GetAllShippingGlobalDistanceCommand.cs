using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetAllShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>
    {
    }
}
