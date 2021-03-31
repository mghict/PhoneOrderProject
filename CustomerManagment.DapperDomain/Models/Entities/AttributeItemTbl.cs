#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeItemTbl")]
    public partial class AttributeItemTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public string AttributeItemName { get; set; }
        public short PriorityId { get; set; }
        public byte Status { get; set; }

        public virtual AttributeInfoTbl Attribute { get; set; }
    }
}
