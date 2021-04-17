using System.Collections.Generic;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllCityByProvinceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.CityTbl>>
    {
        public float ProvinceId { get; set; }
    }
}
