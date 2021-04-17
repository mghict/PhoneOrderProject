namespace SettingManagment.Application.AreaFeature.Commands
{
    public class DeleteAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
    }
}
