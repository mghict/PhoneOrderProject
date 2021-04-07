using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace OKService.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreInfoTbl")]
    public class StoreInfoTbl
    {
        [Dapper.Contrib.Extensions.Key]
        public float Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? IsActive { get; set; }
    }
}
