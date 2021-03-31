using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductByCatValidator : AbstractValidator<Commands.GetProductByCatCommand>
    {
        public GetProductByCatValidator() : base()
        {
            RuleFor(current => current.CategoryId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
