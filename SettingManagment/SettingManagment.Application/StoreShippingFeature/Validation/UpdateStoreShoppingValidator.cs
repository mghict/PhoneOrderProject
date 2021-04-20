using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class UpdateStoreShoppingValidator :
        FluentValidation.AbstractValidator<Commands.UpdateStoreShippingCommand>
    {
        public UpdateStoreShoppingValidator() : base()
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

            RuleFor(current => current.Id)
               .NotEmpty()
               .WithName("کد")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
