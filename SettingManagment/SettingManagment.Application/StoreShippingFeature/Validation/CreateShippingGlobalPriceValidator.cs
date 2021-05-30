using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class CreateShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.CreateShippingGlobalPriceCommand>
    {
        public CreateShippingGlobalPriceValidator() : base()
        {
            RuleFor(current => current.ShippingPrice)
               .GreaterThanOrEqualTo(0)
               .WithName("کرایه حمل")
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.FromSum)
               .GreaterThanOrEqualTo(0)
               .WithName("بازه ابتدایی")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.ToSum)
               .GreaterThan(0)
               .WithName("بازه انتهایی")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .GreaterThanOrEqualTo(c=>c.FromSum)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);
            

        }
    }
}
