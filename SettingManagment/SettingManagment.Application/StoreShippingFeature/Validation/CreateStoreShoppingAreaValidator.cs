using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class CreateStoreShoppingAreaValidator :
        FluentValidation.AbstractValidator<Commands.CreateStoreShippingAreaCommand>
    {
        public CreateStoreShoppingAreaValidator() : base()
        {
            RuleFor(current => current.ShippingPrice)
               .NotEmpty()
               .WithName("کرایه حمل")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .ExclusiveBetween(0, int.MaxValue)
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.StoreID)
               .NotEmpty()
               .WithName("کد فروشگاه")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.Priority)
               .NotEmpty()
               .WithName("اولویت")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.AreaID)
               .NotEmpty()
               .WithName("منطقه جغرافیایی")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            //RuleFor(current => current.DrivingTime)
            //   .NotEmpty()
            //   .WithName("حداکثر زمان پوششدهی پیک")
            //   .WithErrorCode("10")
            //   .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
            //   .NotNull()
            //   .WithErrorCode("11")
            //   .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
