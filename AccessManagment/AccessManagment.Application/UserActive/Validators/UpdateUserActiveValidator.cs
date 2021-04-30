using FluentValidation;

namespace AccessManagment.Application.UserActive.Validators
{
    public class UpdateUserActiveValidator : AbstractValidator<Commands.UpdateUserActiveCommands>
    {
        public UpdateUserActiveValidator() : base()
        {
            RuleFor(current => current.Id)
            .NotEmpty()
            .WithName("کد")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

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

            RuleFor(current => current.Status)
            .NotEmpty()
            .WithName("وضعیت")
            .WithErrorCode("10")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            .NotEmpty()
            .WithErrorCode("11")
            .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }

}
