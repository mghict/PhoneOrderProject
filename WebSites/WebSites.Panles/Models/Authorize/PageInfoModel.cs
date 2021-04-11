using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Authorize
{
    public class PageInfoModel
    {
        [Display(Name = "کد صفحه")]
        public int Id { get; set; }

        [Display(Name = "نام کنترلر")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string PageName { get; set; }

        [Display(Name = "نام صفحه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string DisplayName { get; set; }

        [Display(Name = "کد سیستم")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ApplicationId { get; set; }

        [Display(Name = "کد والد")]
        public int ParentId { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public bool Status { get; set; }
    }
}
