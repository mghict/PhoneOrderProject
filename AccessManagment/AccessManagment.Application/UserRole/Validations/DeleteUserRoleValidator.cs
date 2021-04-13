using FluentValidation;

namespace AccessManagment.Application.UserRole.Validations
{
    public class DeleteUserRoleValidator : AbstractValidator<Commands.DeleteUserRoleCommand>
    {
        public DeleteUserRoleValidator()
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
