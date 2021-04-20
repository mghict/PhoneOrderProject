using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetByAreaIdAreaGeoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.AreaGeoTbl>>
    {
        public int AreaId { get; set; }
    }
}
