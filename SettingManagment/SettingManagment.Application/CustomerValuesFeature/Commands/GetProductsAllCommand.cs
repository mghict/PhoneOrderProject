namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetProductsAllCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.ProductsModel>
    {
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
