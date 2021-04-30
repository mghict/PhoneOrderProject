using FluentValidation;

namespace AccessManagment.Application.UserActive.Validators
{
    public class GetAllUserActiveCurrentDateValidator : AbstractValidator<Commands.GetAllUserActiveCurrentDateCommands>
    {
        public GetAllUserActiveCurrentDateValidator() : base()
        {
            RuleFor(current => current.ApplicationId)
            .NotEmpty()
            .WithName("کد سیستم")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }

}
