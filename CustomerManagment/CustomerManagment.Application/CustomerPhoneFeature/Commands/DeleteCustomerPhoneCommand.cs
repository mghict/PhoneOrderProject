namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class DeleteCustomerPhoneCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public DeleteCustomerPhoneCommand()
        {

        }
        public long Id { get; set; }
    }
}