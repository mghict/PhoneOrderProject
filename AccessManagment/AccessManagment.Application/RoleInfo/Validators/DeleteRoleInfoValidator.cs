using FluentValidation;

namespace AccessManagment.Application.RoleInfo.Validators
{
    public class DeleteRoleInfoValidator :
        FluentValidation.AbstractValidator<Commands.DeleteRoleInfoCommand>
    {
        public DeleteRoleInfoValidator() : base()
        {
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
