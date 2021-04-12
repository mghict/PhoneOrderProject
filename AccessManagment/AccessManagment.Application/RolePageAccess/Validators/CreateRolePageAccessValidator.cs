using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace AccessManagment.Application.RolePageAccess.Validators
{
    public class CreateRolePageAccessValidator:AbstractValidator<Commands.CreateRolePageAccessCommand>
    {
        public CreateRolePageAccessValidator():base()
        {
            RuleForEach(current => current.Permision)
                .SetValidator(new RolePagesAccessValidator());
        }
    }

    public class RolePagesAccessValidator : AbstractValidator<Domain.Entities.RolePagesAccess>
    {
        public RolePagesAccessValidator()
        {
            RuleFor(current=>current.IsAccess)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.PageId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

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
