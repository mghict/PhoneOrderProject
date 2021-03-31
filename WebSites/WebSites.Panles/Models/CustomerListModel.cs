using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSites.Panles.Helper;


namespace WebSites.Panles.Models
{
    public class CustomerListModel
    {
        public FluentResult<CustomerAttribute> CustomerGroup { get; set; }
        public FluentResult<CustomerAttribute> CustomerType { get; set; }
        public FluentResult<CustomerAttribute> CustomerRegisterType { get; set; }
        public FluentResult<CustomerAttribute> CustomerSex { get; set; }
        public FluentResult<CustomerAttribute> CustomerJob { get; set; }
        public FluentResult<CustomerAttribute> CustomerEducation { get; set; }
    }
}
