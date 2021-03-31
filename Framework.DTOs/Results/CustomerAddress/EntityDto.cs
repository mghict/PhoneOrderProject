using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.CustomerAddress
{
    public class EntityDto:Base.DtoResultBase
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public int AddressType { get; set; }
        public string AddressValue { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }
    }
}
