namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByIdStoreShippingAreaCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreShippingAreaTbl>
    {
        public int Id { get; set; }
    }
}
