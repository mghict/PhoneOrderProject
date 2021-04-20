using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.CustomerAddress
{
    public class CustomerAddressModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AddressType { get; set; }
        public string AddressTypeStr { get; set; }
        public string AddressValue { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public byte Status { get; set; }
        public string StatusStr { get; set; }
    }
}
