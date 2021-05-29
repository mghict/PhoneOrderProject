using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetRangeForAmountShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>
    {
        public int Amount { get; set; }
    }
}
