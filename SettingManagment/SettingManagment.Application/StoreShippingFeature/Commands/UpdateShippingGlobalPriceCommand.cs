namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class UpdateShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
        public int FromSum { get; set; }
        public int ToSum { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
