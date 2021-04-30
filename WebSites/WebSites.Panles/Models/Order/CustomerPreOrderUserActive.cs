using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WebSites.Panles.Models.Order
{
    
    public class CustomerPreOrderUserActive
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public long OrderCode { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string StatusDescription { get; set; }
    }
}
