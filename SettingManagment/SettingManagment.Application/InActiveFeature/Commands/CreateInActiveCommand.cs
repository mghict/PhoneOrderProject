using System;

namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class CreateInActiveCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool Status { get; set; }
    }
}
