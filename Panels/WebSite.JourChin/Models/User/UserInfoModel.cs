using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.JourChin.Models.User
{
    public class UserInfoModel
    {
        [Display(Name = "کد کاربر")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تایید رمزعبور")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "رمز عبور فعلی")]
        public string CurrentPassword { get; set; }

        [Display(Name = "کد فروشگاه")]
        public string Storeid { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

        [Display(Name = "مشخصات کاربر")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Name { get; set; }
    }
}
