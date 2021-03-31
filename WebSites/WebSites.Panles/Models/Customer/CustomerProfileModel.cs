using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Customer
{
    public class CustomerProfileModel
    {
        public Models.Customer.CustomerInfoModel GetCustomerInfo { get; set; }
        public List<Models.CustomerAddress.CustomerAddressModel> GetCustomerAddresses { get; set; }
        public List<Models.CustomerPhone.CustomerPhoneModel> GetCustomerPhones { get; set; }
    }
}
