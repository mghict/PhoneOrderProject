using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Validators
{
    public class ValidatorBase<T> : FluentValidation.AbstractValidator<T>
    {
        public ValidatorBase() : base()
        {

        }
    }
}
