using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class UpdateShippingGlobalValidator :
        FluentValidation.AbstractValidator<Commands.UpdateShippingGlobalCommand>
    {
        public UpdateShippingGlobalValidator() : base()
        {
            RuleFor(current => current.ShippingPrice)
               .NotEmpty()
               .WithName("کرایه حمل")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }

}
