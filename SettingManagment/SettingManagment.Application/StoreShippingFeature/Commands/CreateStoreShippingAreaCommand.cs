using System;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class CreateStoreShippingAreaCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public float StoreID { get; set; }
        public int AreaID { get; set; }
        public TimeSpan DrivingTime { get; set; }
        public int ShippingPrice { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; }
    }
}
