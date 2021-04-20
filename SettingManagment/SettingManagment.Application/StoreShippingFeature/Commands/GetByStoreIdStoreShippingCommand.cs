namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class GetByStoreIdStoreShippingCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreShippingTbl>
    {
        public float StoreId { get; set; }
    }
}
