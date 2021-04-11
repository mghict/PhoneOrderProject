using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Authorize
{
    public class ApplicationInfoModel
    {
        [Display(Name = "کد سیستم")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int Id { get; set; }

        [Display(Name = "نام سیستم")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string ApplicationName { get; set; }

        [Display(Name = "وضعیت سیستم")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public bool Status { get; set; }
    }
}
