using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.TimeSheetFeature.Commands
{
    public class GetAllTimeSheetCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.StoreTimeSheetTbl>>
    {
    }
}
