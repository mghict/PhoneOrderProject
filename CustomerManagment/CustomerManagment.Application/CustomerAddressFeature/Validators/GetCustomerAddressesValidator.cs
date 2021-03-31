using FluentValidation;

namespace CustomerManagment.Application.CustomerAddressFeature.Validators
{
    public class GetCustomerAddressesValidator : FluentValidation.AbstractValidator<Commands.GetCustomerAddressesCommand>
    {
        public GetCustomerAddressesValidator() : base()
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