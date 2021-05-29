using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class CreateShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.CreateShippingGlobalPriceCommand>
    {
        public CreateShippingGlobalPriceValidator() : base()
        {
            RuleFor(current => current.ShippingPrice)
               .ExclusiveBetween(0, int.MaxValue)
               .WithName("کرایه حمل")
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.FromSum)
               .NotEmpty()
               .WithName("بازه ابتدایی")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ToSum)
               .NotEmpty()
               .WithName("بازه انتهایی")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
