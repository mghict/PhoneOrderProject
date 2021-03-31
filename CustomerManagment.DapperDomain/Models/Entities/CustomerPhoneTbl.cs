#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerPhoneTbl")]
    public partial class CustomerPhoneTbl : Models.Base.Entity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int PhoneType { get; set; }
        public long PhoneValue { get; set; }
        public byte Status { get; set; }

        public virtual CustomerInfoTbl Customer { get; set; }
    }
}
