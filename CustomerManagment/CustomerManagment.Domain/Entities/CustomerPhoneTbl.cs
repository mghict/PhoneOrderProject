#nullable disable

namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPhoneTbl")]
    public partial class CustomerPhoneTbl : BehsamFramework.Entity.IEntity<long>
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public long PhoneValue { get; set; }
        public byte Status { get; set; }

    }
}
