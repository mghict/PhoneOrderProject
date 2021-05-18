using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetOrderItemsReserveDetailsValidator : FluentValidation.AbstractValidator<Commands.GetOrderItemsReserveDetailsCommand>
    {
        public GetOrderItemsReserveDetailsValidator() : base()
        {
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
