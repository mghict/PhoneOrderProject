namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class GetProductByBarCodeCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.ProductInfoTbl>
    {
        public float StoreId { get; set; }
        public string Barcode { get; set; }
    }
}
