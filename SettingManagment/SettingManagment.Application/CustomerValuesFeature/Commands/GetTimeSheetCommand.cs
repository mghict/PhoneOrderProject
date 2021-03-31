using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetTimeSheetCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<BehsamFramework.Models.TimeSheetTableModel>>
    {
        public GetTimeSheetCommand():base()
        {

        }

        public DateTime RequestDate { get; set; }
    }
}
