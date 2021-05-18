using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class DeleteOrderItemsReserveValidator : FluentValidation.AbstractValidator<Commands.DeleteOrderItemsReserveCommand>
    {
        public DeleteOrderItemsReserveValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithName("کد")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

           

        }
    }
}
