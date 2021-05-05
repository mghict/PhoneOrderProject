using FluentValidation;

namespace BillManagement.Application.BillFeature.Validators
{
    public class UpdateOrderDetailValidator : AbstractValidator<Commands.UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailValidator() : base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithName("شماره سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.OrderItems)
                .Must(list => list.Count > 0)
                .WithName("کالاهای سفارش")
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleForEach(current => current.OrderItems)
                .SetValidator(new OrderItemsValidator());
        }
    }
}
