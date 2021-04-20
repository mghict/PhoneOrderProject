using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class CreateAreaGeoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public List<Domain.Entities.AreaGeoTbl> Points { get; set; }
    }
}
