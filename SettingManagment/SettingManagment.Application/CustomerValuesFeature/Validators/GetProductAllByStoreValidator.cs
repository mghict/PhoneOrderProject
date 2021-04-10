using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductAllByStoreValidator : AbstractValidator<Commands.GetProductsAllByStoreCommand>
    {
        public GetProductAllByStoreValidator() : base()
        {

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
