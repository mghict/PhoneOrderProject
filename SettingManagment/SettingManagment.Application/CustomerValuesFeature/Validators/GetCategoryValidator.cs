using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SettingManagment.Application.CustomerValuesFeature.Validators
{
    public class GetCategoryValidator : FluentValidation.AbstractValidator<Commands.GetCategoryCommand>
    {
        public GetCategoryValidator():base()
        {
            //RuleFor(current=>current.CategoryId)
            //    .NotEmpty()
            //    .WithErrorCode("10")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired)
            //    .NotEmpty()
            //    .WithErrorCode("11")
            //    .WithMessage(BehsamFramework.Resources.Messages.ErrorRequired);
            
        }
    }
}
