using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models
{
    public class AttributeStatus : BehsamFramework.Entity.IEntity<int>
    {
        public AttributeStatus() : base()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public byte StatusId { get; set; }
        public bool Status { get; set; }
    }
}
