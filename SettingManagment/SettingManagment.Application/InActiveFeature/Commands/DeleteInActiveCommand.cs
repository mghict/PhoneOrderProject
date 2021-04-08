namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class DeleteInActiveCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
    }
}
