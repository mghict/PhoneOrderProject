using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Safir.Models
{
    public class UserPassModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string UserName { get; set; }

        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Password { get; set; }
    }
}
