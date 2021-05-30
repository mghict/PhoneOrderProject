using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetRangeForDistanceShippingGlobalDistanceValidator :
        FluentValidation.AbstractValidator<Commands.GetRangeForDistanceShippingGlobalDistanceCommand>
    {
        public GetRangeForDistanceShippingGlobalDistanceValidator() : base()
        {
            RuleFor(current => current.Distance)
               .NotEmpty()
               .WithName("فاصله")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
