using FluentValidation;

namespace UserManagment.Application.UsersFeature.Validators
{
    public class ResetAminPasswordValidator :
        FluentValidation.AbstractValidator<Commands.ResetAdminPasswordCommand>
    {
        public ResetAminPasswordValidator() : base()
        {
            
            RuleFor(current => current.NewPassword)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.NewRetPassword)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.NewPassword)
                .Equal(current => current.NewPassword)
                .WithErrorCode("12")
                .WithMessage(BehsamFramework.Resources.Messages.PasswordNotEqualConfirm);

            RuleFor(current => current.UserName)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}