using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Area
{
    public class AreaInfoModel
    {
        [Display(Name = "کد")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public string AreaName { get; set; }

        [Display(Name = "نوع")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int AreaType { get; set; }

        [Display(Name = "پدر")]
        public int ParentID { get; set; }

        [Display(Name = "مختصات جغرافیایی")]
        public float CenterLatitude { get; set; }

        [Display(Name = "مختصات جغرافیایی")]
        public float Centerlongitude { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "مقدار {0} اجباری می باشد")]
        public int CityId { get; set; }

        [Display(Name = "نام پدر")]
        public string ParentName { get; set; }

        [Display(Name = "نام شهر")]
        public string CityName { get; set; }

        [Display(Name = "نوع")]
        public string AreaTypeName { get; set; }
    }
}
