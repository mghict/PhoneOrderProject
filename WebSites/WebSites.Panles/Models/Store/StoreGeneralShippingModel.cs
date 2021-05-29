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

        [Display(Name = "مبلغ کرایه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int ShippingPrice { get; set; }
    }
}
