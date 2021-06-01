using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Store
{
    public class StoreGeneralShippingPriceModel
    {

        public int Id { get; set; }

        [Display(Name = "از مبلغ فاکتور")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int FromSum { get; set; }

        [Display(Name = "تا مبلغ فاکتور")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ToSum { get; set; }

        [Display(Name = "درصد تخفیف کرایه")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(0, 100, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int ShippingPrice { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

    }
}
