using FluentValidation;

namespace BillManagement.Application.BillFeature.Validators
{
    public class LoginUserValidator : AbstractValidator<Commands.LoginUserCommand>
    {
        public LoginUserValidator() : base()
        {
            RuleFor(current => current.UserName)
                .NotEmpty()
                .WithName("نام کاربری")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.Password)
                .NotEmpty()
                .WithName("رمزعبور")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
