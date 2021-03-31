namespace CustomerManagment.Application.CustomerAddressFeature.Commands
{
    public class DeleteCustomerAddressCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public long Id { get; set; }

    }
}