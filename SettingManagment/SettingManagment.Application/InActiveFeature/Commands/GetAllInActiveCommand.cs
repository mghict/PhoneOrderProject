using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class GetAllInActiveCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<Domain.Entities.InActiveTbl>>
    {
    }
}
