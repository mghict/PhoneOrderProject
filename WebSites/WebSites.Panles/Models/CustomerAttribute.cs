using System.Collections.Generic;

namespace WebSites.Panles.Models
{

    public class CustomerAttribute
    {
        public CustomerAttribute():base()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public bool IsMandetory { get; set; }
        public ICollection<CustomerAttributeValues> ValuesList { get; set; }
    }
}