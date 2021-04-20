using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WebSites.Panles.Models.Store
{
  
    public class StoreShippingTbl
    {
        [Display(Name = "کد")]
        public int Id { get; set; }

        [Display(Name = "کد شعبه")]
        public float StoreID { get; set; }

        [Display(Name = "کرایه حمل")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int ShippingPrice { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }
    }
}
