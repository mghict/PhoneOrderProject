using FluentValidation;

namespace CustomerManagment.Application.CustomerAddressFeature.Validators
{
    public class DeleteCustomerAddressValidator : FluentValidation.AbstractValidator<Commands.DeleteCustomerAddressCommand>
    {
        public DeleteCustomerAddressValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}