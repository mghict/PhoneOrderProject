using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Store
{
    public class StoreGeneralShippingModel
    {
        [Display(Name = "کد")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public byte Id { get; set; }

        [Display(Name = "حداکثر مبلغ کرایه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int ShippingPrice { get; set; }

        [Display(Name = "حداقل مبلغ کرایه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int MinShippingPrice { get; set; }
    }
}
