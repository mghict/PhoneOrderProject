using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class CreateStoreShoppingValidator:
        FluentValidation.AbstractValidator<Commands.CreateStoreShippingCommand>
    {
        public CreateStoreShoppingValidator():base()
        {
            RuleFor(current => current.ShippingPrice)
               .NotEmpty()
               .WithName("کرایه حمل")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .ExclusiveBetween(0, int.MaxValue)
               .WithErrorCode("9")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.StoreID)
               .NotEmpty()
               .WithName("کد فروشگاه")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent)
               .NotNull()
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.ErrorRequiredFluent);
        }
    }

}
