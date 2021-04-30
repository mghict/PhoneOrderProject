using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AccessManagment.Application.UserActive.Validators
{
    public class CreateUserActiveValidator:AbstractValidator<Commands.CreateUserActiveCommands>
    {
        public CreateUserActiveValidator():base()
        {
            RuleFor(current => current.UserId)
            .NotEmpty()
            .WithName("کد کاربر")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.CreateDate)
            .NotEmpty()
            .WithName("تاریخ")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }

}
