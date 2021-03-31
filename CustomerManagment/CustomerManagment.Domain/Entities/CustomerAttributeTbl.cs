﻿using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerAttributeTbl")]
    public partial class CustomerAttributeTbl :BehsamFramework.Entity.IEntity<int>
    {
        public CustomerAttributeTbl()
        {
            CustomerAttributeItemTbls = new HashSet<CustomerAttributeItemTbl>();
        }

        public int Id { get; set; }
        public int AttributeId { get; set; }
        public bool IsReuired { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<CustomerAttributeItemTbl> CustomerAttributeItemTbls { get; set; }
    }
}
