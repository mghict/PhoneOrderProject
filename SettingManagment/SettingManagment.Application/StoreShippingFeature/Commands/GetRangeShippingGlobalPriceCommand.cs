using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetRangeShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>
    {
        public int FromAmount { get; set; }
        public int ToAmount { get; set; }
    }
}
