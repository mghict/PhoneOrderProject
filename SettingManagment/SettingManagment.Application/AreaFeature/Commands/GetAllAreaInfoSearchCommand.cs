namespace SettingManagment.Application.AreaFeature.Commands
{
    public class GetAllAreaInfoSearchCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.AreaModel>
    {
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
