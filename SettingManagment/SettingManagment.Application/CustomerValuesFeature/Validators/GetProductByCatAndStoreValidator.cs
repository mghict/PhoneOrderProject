using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductByCatAndStoreValidator : AbstractValidator<Commands.GetProductByCatAndStoreCommand>
    {
        public GetProductByCatAndStoreValidator() : base()
        {
            RuleFor(current => current.CategoryId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
