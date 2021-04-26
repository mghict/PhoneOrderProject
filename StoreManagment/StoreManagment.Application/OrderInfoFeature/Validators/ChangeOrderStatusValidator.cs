using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class ChangeOrderStatusValidator : AbstractValidator<Commands.ChangeOrderStatusCommand>
    {
        public ChangeOrderStatusValidator() : base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithName("شماره سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            

        }
    }
}
