namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class CreateShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int FromDistance { get; set; }
        public int ToDistance { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
