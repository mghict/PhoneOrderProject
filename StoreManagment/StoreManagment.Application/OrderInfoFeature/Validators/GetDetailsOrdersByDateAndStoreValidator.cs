using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetDetailsOrdersByDateAndStoreValidator : FluentValidation.AbstractValidator<Commands.GetDetailsOrdersByDateAndStore>
    {
        public GetDetailsOrdersByDateAndStoreValidator() : base()
        {
            RuleFor(current => current.OrderDate)
                .NotEmpty()
                .WithName("تاریخ")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("کد فروشگاه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

            RuleFor(current => current.OrderTime)
                .NotEmpty()
                .WithName("زمان ارسال")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);

        }
    }
}
