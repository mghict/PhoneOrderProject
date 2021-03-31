using FluentValidation;

namespace UserAuthorize.Application.UserFeatures.Validators
{
    public class UserAccessCommandValidator :
        FluentValidation.AbstractValidator<Commands.UserAccessCommand>
    {
        public UserAccessCommandValidator() : base()
        {
            RuleFor(current => current.Token)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.MethodName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
