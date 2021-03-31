namespace CustomerManagment.Application.CustomerPhoneFeature.Commands
{
    public class UpdateCustomerPhoneCommand :
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public UpdateCustomerPhoneCommand()
        {

        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public long PhoneValue { get; set; }
        public byte Status { get; set; }
    }
}