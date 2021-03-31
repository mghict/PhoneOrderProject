using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class CustomerEditModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public int RegisterTypeId { get; set; }
        public int Sex { get; set; }
        public int Job { get; set; }
        public int Education { get; set; }
        public byte Status { get; set; }
    }
}
