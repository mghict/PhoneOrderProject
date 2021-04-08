using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.TimeSheetFeature.Commands
{
    public class UpdateTimeSheetCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public byte Id { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public byte StepTime { get; set; }
        public bool Status { get; set; }
    }
}
