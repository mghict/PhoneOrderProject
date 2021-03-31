using System;
using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.CustomerPhone
{
    public class CustomerPhoneRegisterModel
    {
        [Display(Name = "کد مشتری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public long CustomerId { get; set; }

        [Display(Name = "نوع تلفن")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int PhoneType { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1000000000, 9999999999, ErrorMessage = "مقدار {0} صحیح نیست")]
        public long PhoneValue { get; set; }

        [Display(Name = "وضعیت")]
        public byte Status { get; set; }

    }
}
