#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("SystemMessageTbl")]
    public partial class SystemMessageTbl : Models.Base.Entity
    {
        public int Id { get; set; }
        public int MessageType { get; set; }
        public string MessageValue { get; set; }
        public byte Status { get; set; }
    }
}
