using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class CreateItemsReserveValidator : FluentValidation.AbstractValidator<Commands.CreateOrderItemsReserveCommand>
    {
        public CreateItemsReserveValidator() : base()
        {
            RuleFor(current => current.OrderItemId)
                .NotEmpty()
                .WithName("کد آیتم")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ProductId)
                .NotEmpty()
                .WithName("کد محصول جایگزین")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
