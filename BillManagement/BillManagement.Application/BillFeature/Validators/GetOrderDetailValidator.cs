using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BillManagement.Application.BillFeature.Validators
{
    public class GetOrderDetailValidator : AbstractValidator<Commands.GetOrderDetailCommand>
    {
        public GetOrderDetailValidator() : base()
        {
            RuleFor(current => current.OrderCode)
                .NotEmpty()
                .WithName("شماره سفارش")
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
                .NotNull()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }
}
