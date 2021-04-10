
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class CategoryShowModel
    {
        public float Id { get; set; }
        public string CategoryName { get; set; }
        public float ParentId { get; set; }
        public string ParentName { get; set; }
        public string ImageUrl { get; set; }
        public int Priority { get; set; }
        public byte Status { get; set; }
    }
}
