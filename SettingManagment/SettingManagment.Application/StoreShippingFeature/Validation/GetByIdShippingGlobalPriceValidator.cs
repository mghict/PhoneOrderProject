using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetByIdShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.GetByIdShippingGlobalPriceCommand>
    {
        public GetByIdShippingGlobalPriceValidator() : base()
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
