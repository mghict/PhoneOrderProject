using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.Validators
{
    public class CreateRoleInfoValidator :
        FluentValidation.AbstractValidator<Commands.CreateRoleInfoCommand>
    {
        public CreateRoleInfoValidator() : base()
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
        }
    }
}
