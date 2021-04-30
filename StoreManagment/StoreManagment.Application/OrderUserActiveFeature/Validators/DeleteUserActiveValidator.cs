using FluentValidation;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class DeleteUserActiveValidator : AbstractValidator<Commands.DeleteUserActiveCommand>
    {
        public DeleteUserActiveValidator() : base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithName("شماره سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.UserId)
                .NotEmpty()
                .WithName("کد کاربر")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
