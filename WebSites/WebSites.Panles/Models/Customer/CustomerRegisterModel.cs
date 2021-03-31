using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebSites.Panles.Models
{
    public class CustomerRegisterModel
    {

        [Display(Name = "مشخصات مشتری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string CustomerName { get; set; }

        [Display(Name = "تلفن تماس")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1000000000, 9999999999, ErrorMessage = "مقدار {0} صحیح نیست")]
        public long DefaultMobile { get; set; }


        [Display(Name = "نوع مشتری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int CustomerTypeId { get; set; }


        [Display(Name = "گروهبندی")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int CustomerGroupId { get; set; }


        [Display(Name = "نوع ثبت نام")]
        //[Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        //[Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int RegisterTypeId { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int Sex { get; set; }


        [Display(Name = "شغل")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int Job { get; set; }


        [Display(Name = "تحصیلات")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار {0} صحیح نیست")]
        public int Education { get; set; }


        [Display(Name = "وضعیت")]
        //[Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        //[Range(1,int.MaxValue,ErrorMessage = "مقدار {0} صحیح نیست")]
        public byte Status { get; set; }


        
    }
}
