using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetRangeForAmountShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.GetRangeForAmountShippingGlobalPriceCommand>
    {
        public GetRangeForAmountShippingGlobalPriceValidator() : base()
        {
            RuleFor(current => current.Amount)
               .NotEmpty()
               .WithName("مبلغ")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
