using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetSummeryOrdersByDateAndStoreValidator : FluentValidation.AbstractValidator<Commands.GetSummeryOrdersByDateAndStore>
    {
        public GetSummeryOrdersByDateAndStoreValidator() : base()
        {
            RuleFor(current => current.OrderDate)
                .NotEmpty()
                .WithName("تاریخ")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.StoreId)
                .NotEmpty()
                .WithName("کد فروشگاه")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
