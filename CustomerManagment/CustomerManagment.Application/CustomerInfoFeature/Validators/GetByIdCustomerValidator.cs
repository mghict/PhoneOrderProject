using FluentValidation;

namespace CustomerManagment.Application.CustomerInfoFeature.Validators
{
    public class GetByIdCustomerValidator : FluentValidation.AbstractValidator<Commands.GetByIdCustomerCommand>
    {
        public GetByIdCustomerValidator() : base()
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