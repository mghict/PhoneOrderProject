using FluentValidation;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class OrderInfoValidator : FluentValidation.AbstractValidator<Domain.Entities.OrderInfo>
    {
        public OrderInfoValidator() : base()
        {
            RuleFor(current => current.AddressId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.CustomerId)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderCode)
               .NotEmpty()
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
               .NotEmpty()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderDate)
               .NotEmpty()
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
               .NotEmpty()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderTime)
               .NotEmpty()
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
               .NotEmpty()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.StoreId)
               .NotEmpty()
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
               .NotEmpty()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

           
        }
    }
}
