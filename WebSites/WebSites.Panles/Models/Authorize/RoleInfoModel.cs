using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Authorize
{
    public class RoleInfoModel
    {
        [Display(Name = "کد نقش")]
        public int Id { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string RoleName { get; set; }

        [Display(Name = "کد سیستم")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ApplicationId { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }
    }
}
