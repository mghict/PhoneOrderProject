using FluentValidation;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class GetbyUserIdUserCurrentDetailsValidator : FluentValidation.AbstractValidator<Commands.GetbyUserIdUserCurrentDetailsCommand>
    {
        public GetbyUserIdUserCurrentDetailsValidator() : base()
        {

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
