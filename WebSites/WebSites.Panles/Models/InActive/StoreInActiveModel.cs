using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.InActive
{
    public class StoreInActiveModel
    {
        public int Id { get; set; }

        [Display(Name = "کد فروشگاه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string StoreId { get; set; }

        [Display(Name = "عنوان تعطیلی")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string FromDate { get; set; }

        [Display(Name = "تاریخ خاتمه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string ToDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public bool Status { get; set; }
    }
}
