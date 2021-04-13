using FluentValidation;

namespace AccessManagment.Application.User.Validators
{
    public class GetbyIdUserValidator : AbstractValidator<Commands.GetByIdUserCommand>
    {
        public GetbyIdUserValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
