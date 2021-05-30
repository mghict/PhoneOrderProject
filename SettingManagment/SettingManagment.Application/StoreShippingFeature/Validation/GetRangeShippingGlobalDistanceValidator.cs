using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetRangeShippingGlobalDistanceValidator :
        FluentValidation.AbstractValidator<Commands.GetRangeShippingGlobalDistanceCommand>
    {
        public GetRangeShippingGlobalDistanceValidator() : base()
        {
            RuleFor(current => current.FromDistance)
               .GreaterThanOrEqualTo(0)
               .WithName("بازه ابتدا")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.ToDistance)
               .GreaterThan(0)
               .WithName("بازه انتها")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .GreaterThanOrEqualTo(c=>c.FromDistance)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);
        }
    }
}
