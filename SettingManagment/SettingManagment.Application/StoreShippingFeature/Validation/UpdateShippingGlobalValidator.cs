using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class UpdateShippingGlobalValidator :
        FluentValidation.AbstractValidator<Commands.UpdateShippingGlobalCommand>
    {
        public UpdateShippingGlobalValidator() : base()
        {
            RuleFor(current => current.ShippingPrice)
               .GreaterThanOrEqualTo(0)
               .WithName("کرایه حمل")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.ShippingPrice)
               .GreaterThanOrEqualTo(0)
               .WithName("حداقل کرایه حمل")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);
        }
    }

}
