using FluentValidation;

namespace CustomerManagment.Application.CustomerAddressFeature.Validators
{
    public class GetByIdCustomerAddressValidator : FluentValidation.AbstractValidator<Commands.GetByIdCustomerAddressCommand>
    {
        public GetByIdCustomerAddressValidator() : base()
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