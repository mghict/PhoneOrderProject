using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetRangeShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>
    {
        public int FromDistance { get; set; }
        public int ToDistance { get; set; }
    }
}
