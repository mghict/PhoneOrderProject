namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class DeleteShippingGlobalDistanceCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
    }
}
