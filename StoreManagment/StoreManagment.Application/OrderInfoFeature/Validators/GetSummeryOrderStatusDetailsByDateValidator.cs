using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetSummeryOrderStatusDetailsByDateValidator : AbstractValidator<Commands.GetSummeryOrderStatusDetailsByDate>
    {
        public GetSummeryOrderStatusDetailsByDateValidator() : base()
        {
            RuleFor(current => current.StartDate)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.EndDate)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            //RuleFor(current => current.StoreId)
            //    .NotEmpty()
            //    .WithErrorCode("10")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            //    .NotNull()
            //    .WithErrorCode("11")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

        }
    }

}
