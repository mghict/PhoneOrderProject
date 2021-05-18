using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.InActive
{
    public class StoreInActiveTbl
    {
        public int Id { get; set; }

        [Display(Name = "کد فروشگاه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public float StoreId { get; set; }

        [Display(Name = "عنوان تعطیلی")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public DateTime FromDate { get; set; }

        [Display(Name = "تاریخ خاتمه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public DateTime ToDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public bool Status { get; set; }
    }
}
