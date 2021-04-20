namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class DeleteStoreShippingAreaCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        
    }
}
