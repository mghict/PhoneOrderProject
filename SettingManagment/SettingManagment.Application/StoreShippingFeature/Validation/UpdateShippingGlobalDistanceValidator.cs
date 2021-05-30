using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class UpdateShippingGlobalDistanceValidator :
        FluentValidation.AbstractValidator<Commands.UpdateShippingGlobalDistanceCommand>
    {
        public UpdateShippingGlobalDistanceValidator() : base()
        {
            RuleFor(current => current.Id)
               .NotEmpty()
               .WithName("کد")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ShippingPrice)
               .GreaterThanOrEqualTo(0)
               .WithName("کرایه حمل")
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.FromDistance)
               .GreaterThanOrEqualTo(0)
               .WithName("بازه ابتدایی")
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.ToDistance)
               .GreaterThan(0)
               .WithName("بازه انتهایی")
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .GreaterThanOrEqualTo(c => c.FromDistance)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

        }
    }
}
