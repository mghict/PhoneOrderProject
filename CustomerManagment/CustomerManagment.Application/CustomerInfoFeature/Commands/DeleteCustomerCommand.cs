namespace CustomerManagment.Application.CustomerInfoFeature.Commands
{
    public class DeleteCustomerCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public long Id { get; set; }

    }
}