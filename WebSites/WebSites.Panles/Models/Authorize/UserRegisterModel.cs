using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.Authorize
{
    public class UserRegisterModel
    {
        [Display(Name = "مشخصات کاربر")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Name { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Password { get; set; }

        [Display(Name = "تایید رمزعبور")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string PasswordConfirm { get; set; }


        [Display(Name = "کد فروشگاه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public float Storeid { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

        
    }
}
