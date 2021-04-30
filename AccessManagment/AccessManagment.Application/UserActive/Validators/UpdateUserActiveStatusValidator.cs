using FluentValidation;

namespace AccessManagment.Application.UserActive.Validators
{
    public class UpdateUserActiveStatusValidator : AbstractValidator<Commands.UpdateUserActiveStatusCommands>
    {
        public UpdateUserActiveStatusValidator() : base()
        {
            RuleFor(current => current.UserId)
            .NotEmpty()
            .WithName("کد")
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
