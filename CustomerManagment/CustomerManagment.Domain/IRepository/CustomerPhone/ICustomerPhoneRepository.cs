using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerPhone
{
    public interface ICustomerPhoneRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.CustomerPhoneTbl,long>
    {
    }
}
