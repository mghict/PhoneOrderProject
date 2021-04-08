namespace SettingManagment.Application.InActiveFeature.Commands
{
    public class GetByIdInActiveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.InActiveTbl>
    {
        public int Id { get; set; }
    }
}
