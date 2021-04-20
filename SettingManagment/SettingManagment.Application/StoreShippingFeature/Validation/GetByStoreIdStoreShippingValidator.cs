using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetByStoreIdStoreShippingValidator :
        FluentValidation.AbstractValidator<Commands.GetByStoreIdStoreShippingCommand>
    {
        public GetByStoreIdStoreShippingValidator() : base()
        {
            

            RuleFor(current => current.StoreId)
               .NotEmpty()
               .WithName("کد فروشگاه")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            
        }
    }

}
