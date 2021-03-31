using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class CustomerValuesValidator:FluentValidation.AbstractValidator<Commands.CustomerValuesCommand>
    {
        public CustomerValuesValidator():base()
        {
            RuleFor(current=>current.Id)
                .NotEmpty()
                .WithErrorCode("10")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .NotEmpty()
                .WithErrorCode("11")
                .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
                .ExclusiveBetween(0,int.MaxValue)
                .WithErrorCode("9")
                .WithMessage(BehsamFramework.Resources.Messages.MaxLenghtFluent);
        }
    }
}
