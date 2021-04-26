using FluentValidation;

namespace AccessManagment.Application.User.Validators
{
    public class GetAllUserByAppIdAndStoreIdAndSearchValidator : AbstractValidator<Commands.GetAllUserByAppIdAndStoreIdAndSearchCommand>
    {
        public GetAllUserByAppIdAndStoreIdAndSearchValidator() : base()
        {
            RuleFor(current => current.ApplicationId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
