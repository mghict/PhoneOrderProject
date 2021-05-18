namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class GetByIdStoreInActiveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.StoreInActiveTbl>
    {
        public int Id { get; set; }
    }
}
