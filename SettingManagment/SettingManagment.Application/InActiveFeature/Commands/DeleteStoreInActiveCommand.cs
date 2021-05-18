namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class DeleteStoreInActiveCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
    }
}
