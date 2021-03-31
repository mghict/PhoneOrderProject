using FluentValidation;

namespace CustomerManagment.Application.CustomerPhoneFeature.Validators
{
    public class DeleteCustomerPhoneValidator : FluentValidation.AbstractValidator<Commands.DeleteCustomerPhoneCommand>
    {
        public DeleteCustomerPhoneValidator() : base()
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