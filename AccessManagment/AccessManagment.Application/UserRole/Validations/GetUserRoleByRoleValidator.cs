using FluentValidation;

namespace AccessManagment.Application.UserRole.Validations
{
    public class GetUserRoleByRoleValidator : AbstractValidator<Commands.GetUserRoleByRoleCommand>
    {
        public GetUserRoleByRoleValidator()
        {
            RuleFor(current => current.RoleId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}
