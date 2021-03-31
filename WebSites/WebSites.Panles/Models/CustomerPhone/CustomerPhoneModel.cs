using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.CustomerPhone
{
    public class CustomerPhoneModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public string PhoneTypeStr { get; set; }
        public long PhoneValue { get; set; }
        public string PhoneValueStr { get; set; }
        public byte Status { get; set; }
        public string StatusStr { get; set; }
    }
}
