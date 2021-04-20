using System;
using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models.Store
{
    public class StoreShippingAreaTbl
    {
        [Display(Name = "کد")]
        public int Id { get; set; }

        [Display(Name = "کد فروشگاه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public float StoreID { get; set; }

        [Display(Name = "کد منطقه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int AreaID { get; set; }

        [Display(Name = "مبلغ کرایه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ShippingPrice { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int Priority { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

        [Display(Name = "نام منطقه")]
        public string AreaName { get; set; }
    }
}
