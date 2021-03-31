using FluentValidation;

namespace CustomerManagment.Application.CustomerPhoneFeature.Validators
{
    public class GetCustomerPhonesValidator : FluentValidation.AbstractValidator<Commands.GetCustomerPhonesCommand>
    {
        public GetCustomerPhonesValidator() : base()
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