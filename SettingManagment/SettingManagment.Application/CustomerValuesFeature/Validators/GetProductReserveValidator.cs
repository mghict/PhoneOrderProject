using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetProductReserveValidator : AbstractValidator<Commands.GetProductReserveCommand>
    {
        public GetProductReserveValidator() : base()
        {
            RuleFor(current => current.ItemId)
                .NotEmpty()
                .WithName("کد آیتم")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("کد شعبه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
