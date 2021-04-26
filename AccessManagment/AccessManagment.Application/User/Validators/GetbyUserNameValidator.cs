using FluentValidation;

namespace AccessManagment.Application.User.Validators
{
    public class GetbyUserNameValidator : AbstractValidator<Commands.GetByUserNameCommand>
    {
        public GetbyUserNameValidator() : base()
        {
            RuleFor(current => current.UserName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
