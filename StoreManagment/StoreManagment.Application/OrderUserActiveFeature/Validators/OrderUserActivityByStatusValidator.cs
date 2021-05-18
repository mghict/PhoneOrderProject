using FluentValidation;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class OrderUserActivityByStatusValidator : 
        FluentValidation.AbstractValidator<Commands.OrderUserActivityByStatusCommand>
    {
        public OrderUserActivityByStatusValidator() : base()
        {

            RuleFor(current => current.UserId)
                .NotEmpty()
                .WithName("کد کاربر")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.Status)
                .NotEmpty()
                .WithName("وضعیت سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
