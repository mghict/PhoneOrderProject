using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public static class GeneralMessages
    {
        public const string Input_Mandetory = "{PropertyName} : مقدار الزامی است";

        public const string Input_NotValid = "{PropertyName} : مقدار ورودی صحیح نمی باشد";
        public const string Input_Null = "{PropertyName} : مقدار ورودی خالی می باشد";


        public const string Input_MustIsDigit = "{PropertyName} : باید عددی باشد";
        public const string Input_MustIsDecimal = "{PropertyName} : مقدار باید اعشاری باشد";
        public const string Input_MustIsLetter = "{PropertyName} : مقدار باید کاراکتری باشد";
        public const string Input_MustIsDigitAndLetter = "{PropertyName} : مقدار باید ترکیبی از حروف و عدد باشد";
    }
}

