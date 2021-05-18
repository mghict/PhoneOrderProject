using System;

namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class CreateStoreInActiveCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public float StoreId { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
