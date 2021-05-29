using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class ReplaceProductToOrderValidator : FluentValidation.AbstractValidator<Commands.ReplaceProductToOrderCommand>
    {
        public ReplaceProductToOrderValidator() : base()
        {
            RuleFor(current => current.OrginalItemId)
                .NotEmpty()
                .WithName("کد آیتم")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ReplaceProductId)
                .NotEmpty()
                .WithName("کد کالا جایگزین")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
