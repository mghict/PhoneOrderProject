using System;

namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class EditStoreInActiveCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
        public float StoreId { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool Status { get; set; }
    }
}
