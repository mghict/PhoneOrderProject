using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetRangeShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.GetRangeShippingGlobalPriceCommand>
    {
        public GetRangeShippingGlobalPriceValidator() : base()
        {
            RuleFor(current => current.FromAmount)
               .NotEmpty()
               .WithName("بازه ابتدا")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ToAmount)
               .NotEmpty()
               .WithName("بازه انتها")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
