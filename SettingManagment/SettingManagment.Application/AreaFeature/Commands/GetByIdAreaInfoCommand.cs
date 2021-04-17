namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetByIdAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.AreaInfoTbl>
    {
        public int Id { get; set; }
    }
}
