using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace CustomerManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CustomerAddressAreaInfo")]
    public class CustomerAddressAreaInfo:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int AreaId { get; set; }
        public long CustomerAddressId { get; set; }
        public bool Status { get; set; }
    }

}
