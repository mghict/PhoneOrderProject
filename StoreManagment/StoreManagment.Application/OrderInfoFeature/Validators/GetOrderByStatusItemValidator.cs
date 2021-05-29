using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetOrderByStatusItemValidator : AbstractValidator<Commands.GetOrderByStatusItem>
    {
        public GetOrderByStatusItemValidator() : base()
        {
            RuleFor(current => current.Status)
                .NotEmpty()
                .WithName("وضعیت")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.ItemStatus)
                .NotEmpty()
                .WithName("وضعیت اقلام کالا")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
