using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetAllStoreShippingAreaCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreShippingAreaTbl>>
    {
    }
}
