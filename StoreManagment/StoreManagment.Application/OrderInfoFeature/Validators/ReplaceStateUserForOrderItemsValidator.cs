using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class ReplaceStateUserForOrderItemsValidator : AbstractValidator<Commands.ReplaceStateUserForOrderItemsCommand>
    {
        public ReplaceStateUserForOrderItemsValidator() : base()
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

        }
    }
}
