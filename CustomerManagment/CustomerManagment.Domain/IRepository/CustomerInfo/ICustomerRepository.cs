using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerInfo
{
    public interface ICustomerRepository:BehsamFramework.DapperDomain.Base.IRepository<Entities.CustomerInfoTbl,long>
    {
    }
}
