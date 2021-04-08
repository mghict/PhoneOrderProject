using System;
using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.TimeSheet
{
    public class StoreTimeSheetTbl:
        BehsamFramework.Entity.IEntity<byte>
    {
        [Display(Name = "کد لیست")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public byte Id { get; set; }

        [Display(Name = "مشخصات")]
        public string Name { get; set; }

        [Display(Name = "از روز")]
        public byte FromDay { get; set; }

        [Display(Name = "تا روز")]
        public byte ToDay { get; set; }

        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "ساعت خاتمه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public TimeSpan ToTime { get; set; }

        [Display(Name = "بازه زمانی")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public byte StepTime { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }
    }
}
