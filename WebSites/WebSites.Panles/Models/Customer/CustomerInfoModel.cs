using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Customer
{
    public class CustomerInfoModel
    {
        public long Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerTypeStr { get; set; }
        public int CustomerGroupId { get; set; }
        public string CustomerGroupStr { get; set; }
        public long WaletPrice { get; set; }
        public int Score { get; set; }
        public int RegisterTypeId { get; set; }
        public string RegisterTypeStr { get; set; }
        public int Sex { get; set; }
        public string SexStr { get; set; }
        public int Job { get; set; }
        public string JobStr { get; set; }
        public int Education { get; set; }
        public string EducationStr { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterDateStr { get; set; }
        public byte Status { get; set; }
        public string StatusStr { get; set; }
        public string DefaultMobile { get; set; }
    }
}
