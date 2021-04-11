using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.ApplicationInfo.Commands
{
    public class GetAllApplicationInfoCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.ApplicationInfoTbl>>
    {
    }
}
