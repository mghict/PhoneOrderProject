using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class UpdateItemsReserveValidator : FluentValidation.AbstractValidator<Commands.UpdateOrderItemsReserveCommand>
    {
        public UpdateItemsReserveValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithName("کد")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

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

            RuleFor(current => current.Status)
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
