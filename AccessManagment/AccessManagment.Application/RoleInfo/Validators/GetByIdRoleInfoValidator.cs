using FluentValidation;

namespace AccessManagment.Application.RoleInfo.Validators
{
    public class GetByIdRoleInfoValidator :
        FluentValidation.AbstractValidator<Commands.GetByIdRoleInfoCommand>
    {
        public GetByIdRoleInfoValidator() : base()
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
