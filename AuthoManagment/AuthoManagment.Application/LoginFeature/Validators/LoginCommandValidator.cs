using FluentValidation;

namespace AuthoManagment.Application.LoginFeature.Validators
{
    public class LoginCommandValidator:
        FluentValidation.AbstractValidator<Command.LoginCommand>
    {
        public LoginCommandValidator():base()
        {
            RuleFor(current => current.UserName)
                .NotNull()
                .WithErrorCode(errorCode: "10")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

                .NotEmpty()
                .WithErrorCode(errorCode: "11")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
                ;
            RuleFor(current => current.Password)
                .NotNull()
                .WithErrorCode(errorCode: "10")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

                .NotEmpty()
                .WithErrorCode(errorCode: "11")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
                ;

            RuleFor(current => current.ApplicationId)
                .NotNull()
                .WithErrorCode(errorCode: "10")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

                .NotEmpty()
                .WithErrorCode(errorCode: "11")
                .WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
                ;
        }
    }
}
