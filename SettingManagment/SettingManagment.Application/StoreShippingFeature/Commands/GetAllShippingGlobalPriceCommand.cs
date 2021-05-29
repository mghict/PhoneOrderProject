using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetAllShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>
    {
    }
}
