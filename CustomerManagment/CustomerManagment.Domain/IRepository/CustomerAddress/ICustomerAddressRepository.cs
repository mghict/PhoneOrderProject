using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerAddress
{
    public interface ICustomerAddressRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.CustomerAddressTbl,long>
    {
    }
}
