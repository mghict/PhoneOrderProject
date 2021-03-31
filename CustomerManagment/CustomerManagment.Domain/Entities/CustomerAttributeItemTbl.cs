#nullable disable

namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerAttributeItemTbl")]
    public partial class CustomerAttributeItemTbl :BehsamFramework.Entity.IEntity<long>
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public byte Status { get; set; }

        public virtual CustomerAttributeTbl Attribute { get; set; }
        public virtual CustomerInfoTbl Customer { get; set; }
    }
}
