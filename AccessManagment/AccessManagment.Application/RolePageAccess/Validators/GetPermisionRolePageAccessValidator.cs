using FluentValidation;
namespace AccessManagment.Application.RolePageAccess.Validators
{
    public class GetPermisionRolePageAccessValidator : AbstractValidator<Commands.GetPermisionRolePageAccessCommand>
    {
        public GetPermisionRolePageAccessValidator()
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
