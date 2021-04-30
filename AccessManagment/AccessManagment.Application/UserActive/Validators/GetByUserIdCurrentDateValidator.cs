using FluentValidation;

namespace AccessManagment.Application.UserActive.Validators
{
    public class GetByUserIdCurrentDateValidator : AbstractValidator<Commands.GetByUserIdCurrentDateCommands>
    {
        public GetByUserIdCurrentDateValidator() : base()
        {
            

            RuleFor(current => current.UserId)
            .NotEmpty()
            .WithName("کد کاربر")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }

}
