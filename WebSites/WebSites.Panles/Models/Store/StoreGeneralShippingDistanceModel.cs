using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Store
{
    public class StoreGeneralShippingDistanceModel
    {

        public int Id { get; set; }

        [Display(Name = "از فاصله")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int FromDistance { get; set; }

        [Display(Name = "تا فاصله")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ToDistance { get; set; }

        [Display(Name = "کرایه حمل")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ShippingPrice { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

    }
}
