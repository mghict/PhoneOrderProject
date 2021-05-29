namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByIdShippingGlobalPriceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreGeneralShippingByPriceTbl>
    {
        public int Id { get; set; }
    }
}
