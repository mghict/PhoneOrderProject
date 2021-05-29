using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class GetSummeryOrderByDate : AbstractValidator<Commands.GetSummeryOrderByDate>
    {
        public GetSummeryOrderByDate() : base()
        {
            RuleFor(current => current.StartDate)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.EndDate)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);




        }
    }
}
