namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class CreateShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int FromSum { get; set; }
        public int ToSum { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
