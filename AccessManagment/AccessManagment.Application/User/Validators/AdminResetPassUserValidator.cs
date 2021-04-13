using FluentValidation;

namespace AccessManagment.Application.User.Validators
{
    public class AdminResetPassUserValidator : AbstractValidator<Commands.AdminResetPassUserCommand>
    {
        public AdminResetPassUserValidator() : base()
        {
            RuleFor(current => current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.NewPass)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.NewPassConfirm)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(user => user.NewPass)
                .Equal(user => user.NewPassConfirm)
                .When(user => !string.IsNullOrWhiteSpace(user.NewPass))
                .WithErrorCode("12")
                .WithMessage(BehsamFramework.Resources.Messages.PasswordNotEqualConfirm);

        }
    }
}
