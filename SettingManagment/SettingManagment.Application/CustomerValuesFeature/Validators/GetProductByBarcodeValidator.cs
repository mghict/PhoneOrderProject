using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductByBarcodeValidator : AbstractValidator<Commands.GetProductByBarCodeCommand>
    {
        public GetProductByBarcodeValidator() : base()
        {
            RuleFor(current => current.Barcode)
                .NotEmpty()
                .WithName("بارکد کالا")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("کد شعبه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
