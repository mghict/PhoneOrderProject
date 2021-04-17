using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Map
{
    public class SearchAddressModel
    {
        public int Count { get; set; }
        public List<SearchAddressInfoModel> Items { get; set; }
        
    }

    public class SearchAddressInfoModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Neighbourhood { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public Location Location { get; set; }
    }
}
