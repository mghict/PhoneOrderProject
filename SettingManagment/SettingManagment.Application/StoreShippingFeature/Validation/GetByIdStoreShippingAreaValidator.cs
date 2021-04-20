using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetByIdStoreShippingAreaValidator :
        FluentValidation.AbstractValidator<Commands.GetByIdStoreShippingAreaCommand>
    {
        public GetByIdStoreShippingAreaValidator() : base()
        {

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
