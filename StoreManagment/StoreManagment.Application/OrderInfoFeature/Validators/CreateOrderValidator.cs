using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.Validators
{
    public class CreateOrderValidator:FluentValidation.AbstractValidator<Commands.CreateOrderCommand>
    {
        public CreateOrderValidator():base()
        {
            RuleFor(current => current.OrderInfo)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderInfo.Detail)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderInfo.Items)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderInfo.Items)
                .Must(list=>list.Count>0)
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);

            RuleFor(current => current.OrderInfo)
                .SetValidator(new OrderInfoValidator());

            RuleFor(current => current.OrderInfo.Detail)
                .SetValidator(new OrderDetailValidator());

            RuleForEach(current => current.OrderInfo.Items)
                .SetValidator(new OrderItemValidator());
        }
    }

}
