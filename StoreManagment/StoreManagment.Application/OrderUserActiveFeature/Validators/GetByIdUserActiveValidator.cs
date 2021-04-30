using FluentValidation;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class GetByIdUserActiveValidator : FluentValidation.AbstractValidator<Commands.GetByIdUserActiveCommand>
    {
        public GetByIdUserActiveValidator() : base()
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
