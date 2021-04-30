using FluentValidation;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class GetbyUserIdUserCurrentSummeryValidator : FluentValidation.AbstractValidator<Commands.GetbyUserIdUserCurrentSummeryCommand>
    {
        public GetbyUserIdUserCurrentSummeryValidator() : base()
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
