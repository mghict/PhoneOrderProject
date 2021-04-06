using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    //GetOrderInfoWithItemsCommand

    public class GetOrderInfoWithItemsValidator : FluentValidation.AbstractValidator<Commands.GetOrderInfoWithItemsCommand>
    {
        public GetOrderInfoWithItemsValidator() : base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }
}
