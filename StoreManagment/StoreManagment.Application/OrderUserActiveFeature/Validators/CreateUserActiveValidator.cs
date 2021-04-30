using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.Validators
{
    public class CreateUserActiveValidator : FluentValidation.AbstractValidator<Commands.CreateUserActiveCommand>
    {
        public CreateUserActiveValidator():base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithName("شماره سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.UserId)
                .NotEmpty()
                .WithName("کد کاربر")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.Status)
                .NotEmpty()
                .WithName("وضعیت")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
