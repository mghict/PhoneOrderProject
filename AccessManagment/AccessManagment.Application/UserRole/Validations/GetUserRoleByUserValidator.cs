using FluentValidation;

namespace AccessManagment.Application.UserRole.Validations
{
    public class GetUserRoleByUserValidator : AbstractValidator<Commands.GetUserRoleByUserCommand>
    {
        public GetUserRoleByUserValidator()
        {
            RuleFor(current => current.UserId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
        }
    }
}
