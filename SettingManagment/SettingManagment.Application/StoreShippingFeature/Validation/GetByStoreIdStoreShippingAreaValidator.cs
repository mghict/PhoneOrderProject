using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetByStoreIdStoreShippingAreaValidator :
        FluentValidation.AbstractValidator<Commands.GetByStoreIdStoreShippingAreaCommand>
    {
        public GetByStoreIdStoreShippingAreaValidator() : base()
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
