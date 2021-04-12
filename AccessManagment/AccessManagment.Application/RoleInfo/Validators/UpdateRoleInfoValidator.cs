using FluentValidation;

namespace AccessManagment.Application.RoleInfo.Validators
{
    public class UpdateRoleInfoValidator :
        FluentValidation.AbstractValidator<Commands.UpdateRoleInfoCommand>
    {
        public UpdateRoleInfoValidator() : base()
        {
            RuleFor(current => current.ApplicationId)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.RoleName)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.Status)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.Id)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}
