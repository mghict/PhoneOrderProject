namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class UpdateStoreShippingCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public float StoreID { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
