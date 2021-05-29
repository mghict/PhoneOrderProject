using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{

    public class GetShippingGlobalCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreGeneralShippingTbl>
    {
    }
}
