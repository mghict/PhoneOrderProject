using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class GetPagianationDataModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }

   }
}
