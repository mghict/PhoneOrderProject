using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DTOs.Validators
{
 
    public class CustomerInfoAddValidator : ValidatorBase<Input.CustomerDto.AddDto>
    {
        public CustomerInfoAddValidator() : base()
        {
            RuleFor(current => current.CustomerName)
                        //.Cascade(CascadeMode.Stop) // Defualt: Continue
                        .NotEmpty()
                        .WithName("نام مشتری")// Replace with PropertyName
                        .WithMessage(GeneralMessages.Input_Mandetory);

            RuleFor(current => current.CustomerTypeId)
                .NotEmpty()
                .WithMessage("نوع مشتری")
                .WithMessage(GeneralMessages.Input_Mandetory)
                .Must(Util.IsDigit)
                .WithMessage(GeneralMessages.Input_MustIsDigit);

            RuleFor(current => current.CustomerGroupId)
                .NotEmpty()
                .WithMessage("گروه مشتری")
                .WithMessage(GeneralMessages.Input_Mandetory)
                .Must(Util.IsDigit)
                .WithMessage(GeneralMessages.Input_MustIsDigit);

            RuleFor(current => current.RegisterTypeId)
                .NotEmpty()
                .WithMessage("وضعیت ثبت")
                .WithMessage(GeneralMessages.Input_Mandetory)
                .Must(Util.IsDigit)
                .WithMessage(GeneralMessages.Input_MustIsDigit);

            RuleFor(current => current.Status)
                .NotEmpty()
                .WithMessage("وضعیت")
                .WithMessage(GeneralMessages.Input_Mandetory)
                .Must(Util.IsDigit)
                .WithMessage(GeneralMessages.Input_MustIsDigit);
        }
    }
}
