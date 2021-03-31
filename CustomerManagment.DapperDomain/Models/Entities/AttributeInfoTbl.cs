using System.Collections.Generic;

#nullable disable

namespace Models
{
    [Dapper.Contrib.Extensions.Table("AttributeInfoTbl")]
    public partial class AttributeInfoTbl : Models.Base.Entity
    {
        public AttributeInfoTbl()
        {
            AttributeItemTbls = new HashSet<AttributeItemTbl>();
        }

        public int Id { get; set; }
        public string AttributeName { get; set; }
        public string AttributeType { get; set; }
        public byte AttributeFormatType { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<AttributeItemTbl> AttributeItemTbls { get; set; }
    }
}
