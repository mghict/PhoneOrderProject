using FluentValidation;

namespace SettingManagment.Application.InActiveFeature.Validators
{
    public class DeleteStoreInActiveValidator : FluentValidation.AbstractValidator<Commands.DeleteStoreInActiveCommand>
    {
        public DeleteStoreInActiveValidator() : base()
        {

            RuleFor(current => current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);


        }
    }
}
