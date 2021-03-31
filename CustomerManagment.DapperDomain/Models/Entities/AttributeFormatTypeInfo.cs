#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeFormatTypeInfo")]
    public partial class AttributeFormatTypeInfo : Models.Base.Entity
    {
        public byte Id { get; set; }
        public string AttributeFormatType { get; set; }
        public string AttributeFormatName { get; set; }
    }
}
