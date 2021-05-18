using FluentValidation;

namespace SettingManagment.Application.InActiveFeature.Validators
{
    public class GetByIdStoreInActiveValidator : FluentValidation.AbstractValidator<Commands.GetByIdStoreInActiveCommand>
    {
        public GetByIdStoreInActiveValidator() : base()
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
