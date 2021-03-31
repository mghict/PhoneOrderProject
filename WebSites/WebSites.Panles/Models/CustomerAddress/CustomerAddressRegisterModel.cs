using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.CustomerAddress
{
    public class CustomerAddressRegisterModel
    {
        [Display(Name = "کد مشتری")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public long CustomerId { get; set; }

        [Display(Name = "نوع آدرس")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int AddressType { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string AddressValue { get; set; }

        [Display(Name = "مختصات")]
        //[Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public double Latitude { get; set; }

        [Display(Name = "مختصات")]
        //[Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public double Longitude { get; set; }

        [Display(Name = "منطقه جغرافیایی")]
        public int AreaId { get; set; }

        [Display(Name = "وضعیت")]
        public byte Status { get; set; }
    }
}
