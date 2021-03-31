namespace CustomerManagment.Application.CustomerAddressFeature.Commands
{
    public class GetByIdCustomerAddressCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<BehsamFramework.Models.CustomerAddressModel>
    {
        public long Id { get; set; }

    }
}