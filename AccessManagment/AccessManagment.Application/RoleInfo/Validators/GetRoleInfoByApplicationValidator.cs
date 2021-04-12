using FluentValidation;

namespace AccessManagment.Application.RoleInfo.Validators
{
    public class GetRoleInfoByApplicationValidator :
        FluentValidation.AbstractValidator<Commands.GetRoleInfoByApplicationCommand>
    {
        public GetRoleInfoByApplicationValidator() : base()
        {
            RuleFor(current => current.ApplicationId)
            .NotEmpty()
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            
        }
    }
}
