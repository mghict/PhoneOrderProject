using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetRangeForDistanceShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>
    {
        public int Distance { get; set; }
    }
}
