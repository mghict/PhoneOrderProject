namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetProductsAllByStoreCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.ProductsModel>
    {
        public float StoreId { get; set; }
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
