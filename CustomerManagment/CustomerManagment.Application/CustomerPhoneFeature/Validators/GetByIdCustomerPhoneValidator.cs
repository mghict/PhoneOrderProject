using FluentValidation;

namespace CustomerManagment.Application.CustomerPhoneFeature.Validators
{
    public class GetByIdCustomerPhoneValidator : FluentValidation.AbstractValidator<Commands.GetByIdCustomerPhoneCommand>
    {
        public GetByIdCustomerPhoneValidator() : base()
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