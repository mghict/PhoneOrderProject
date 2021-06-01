namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class UpdateShippingGlobalCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int ShippingPrice { get; set; }
        public int MinShippingPrice { get; set; }
    }
}
