using FluentValidation;

namespace CustomerManagment.Application.CustomerInfoFeature.Validators
{
    public class GetCustomerBySearchValidator : FluentValidation.AbstractValidator<Commands.GetCustomerBySearchCommand>
    {
        public GetCustomerBySearchValidator() : base()
        {
            RuleFor(current => current.SearchKey)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}