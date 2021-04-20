using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetAllStoreShippingCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreShippingTbl>>
    {
    }
}
