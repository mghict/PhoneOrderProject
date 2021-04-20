#nullable disable

namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerAddressTbl")]
    public partial class CustomerAddressTbl : BehsamFramework.Entity.IEntity<long>
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public int AddressType { get; set; }
        public string AddressValue { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int AreaId { get; set; }
        public byte Status { get; set; }

        [Dapper.Contrib.Extensions.Write(false)]
        public string AreaName { get; set; }
    }
}
