namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByIdStoreShippingCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreShippingTbl>
    {
        public int Id { get; set; }
    }
}
