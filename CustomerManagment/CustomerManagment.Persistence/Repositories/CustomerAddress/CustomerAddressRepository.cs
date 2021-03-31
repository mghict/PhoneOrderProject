using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class CustomerAddressRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.CustomerAddressTbl,long>,
        Domain.IRepository.CustomerAddress.ICustomerAddressRepository
    {
        protected internal CustomerAddressRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
