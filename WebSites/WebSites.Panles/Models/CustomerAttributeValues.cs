using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class CustomerAttributeValues 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefualt { get; set; }
        public int AttributeCategoryDetailId { get; set; }
        public CustomerAttribute CustomerAttribute { get; set; }
    }
}
