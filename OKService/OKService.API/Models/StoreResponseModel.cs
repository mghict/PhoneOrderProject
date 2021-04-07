using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKService.API.Models
{
    public class StoreResponseModel
    {
        public float Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? IsActive { get; set; }
    }
}
