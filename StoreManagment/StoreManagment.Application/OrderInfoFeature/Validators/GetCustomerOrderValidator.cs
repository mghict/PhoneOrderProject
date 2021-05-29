using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetCustomerOrderValidator : AbstractValidator<Commands.GetCustomerOrder>
    {
        public GetCustomerOrderValidator() : base()
        {
            RuleFor(current => current.CustomerId)
                .NotEmpty()
                .WithName("مشتری")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.StartDate)
                .NotEmpty()
                .WithName("تاریخ شروع")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.EndDate)
                .NotEmpty()
                .WithName("تاریخ خاتمه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
