namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetCategoriesCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CategoriesModel>
    {
        public string CategoryName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
