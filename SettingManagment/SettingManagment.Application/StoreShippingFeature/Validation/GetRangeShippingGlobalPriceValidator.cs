﻿using FluentValidation;
namespace SettingManagment.Application.StoreShippingFeature.Validation
{
    public class GetRangeShippingGlobalPriceValidator :
        FluentValidation.AbstractValidator<Commands.GetRangeShippingGlobalPriceCommand>
    {
        public GetRangeShippingGlobalPriceValidator() : base()
        {
            RuleFor(current => current.FromAmount)
               .GreaterThanOrEqualTo(0)
               .WithName("بازه ابتدا")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);

            RuleFor(current => current.ToAmount)
               .GreaterThan(0)
               .WithName("بازه انتها")
               .WithErrorCode("10")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .LessThanOrEqualTo(int.MaxValue)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent)
               .GreaterThanOrEqualTo(c=>c.FromAmount)
               .WithErrorCode("11")
               .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);
        }
    }
}
