using System.Collections.Generic;

namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class GetAllStoreInActiveCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreInActiveTbl>>
    {
        public float StoreId { get; set; }
    }
}
