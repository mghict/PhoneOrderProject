using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class ChangeStateUserForOrderItemsValidator : AbstractValidator<Commands.ChangeStateUserForOrderItemsCommand>
    {
        public ChangeStateUserForOrderItemsValidator() : base()
        {
            RuleFor(current => current.OrderId)
                .NotEmpty()
                .WithName("کد سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ItemId)
                .NotEmpty()
                .WithName("کد آیتم")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.State)
                .NotEmpty()
                .WithName("وضعیت")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
