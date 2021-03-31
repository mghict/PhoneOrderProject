#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerAddressTbl")]
    public partial class CustomerAddressTbl : Models.Base.Entity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AddressType { get; set; }
        public string AddressValue { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }

        public virtual CustomerInfoTbl Customer { get; set; }
    }
}
