using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerAddress
{
    public interface ICustomerAddressQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerAddressTbl,long>
    {
        Task<ICollection<Domain.Entities.CustomerAddressTbl>> GetCustomerAddressAsync(long id);
    }
}
