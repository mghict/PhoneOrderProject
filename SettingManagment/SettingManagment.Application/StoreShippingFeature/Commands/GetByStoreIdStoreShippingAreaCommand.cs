using System.Collections.Generic;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByStoreIdStoreShippingAreaCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreShippingAreaTbl>>
    {
        public float StoreId { get; set; }
    }
}
