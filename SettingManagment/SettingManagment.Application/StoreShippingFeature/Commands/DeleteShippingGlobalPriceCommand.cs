namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class DeleteShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
    }
}
