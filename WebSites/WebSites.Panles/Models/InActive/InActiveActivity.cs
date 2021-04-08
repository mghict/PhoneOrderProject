using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.InActive
{
    public class InActiveActivity
    {
        [Display(Name = "کد")]
        public int Id { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string Title { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string FromDate { get; set; }

        [Display(Name = "تاریخ خاتمه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string ToDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }
    }
}
