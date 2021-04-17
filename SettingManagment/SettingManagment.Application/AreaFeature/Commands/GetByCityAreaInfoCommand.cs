using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetByCityAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.AreaInfoTbl>>
    {
        public int CityId { get; set; }
        public int AreaType { get; set; }
    }
}
