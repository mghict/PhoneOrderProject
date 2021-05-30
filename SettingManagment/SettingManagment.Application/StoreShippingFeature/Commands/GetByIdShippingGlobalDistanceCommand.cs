namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByIdShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreGeneralShippingByDistanceTbl>
    {
        public int Id { get; set; }
    }
}
