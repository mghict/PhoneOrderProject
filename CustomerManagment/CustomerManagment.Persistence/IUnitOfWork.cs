using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence
{
    public interface IUnitOfWork: BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepository.CustomerInfo.ICustomerRepository CustomerRepository { get; }
        Domain.IRepository.CustomerAddress.ICustomerAddressRepository CustomerAddressRepository { get; }
        Domain.IRepository.CustomerPhone.ICustomerPhoneRepository CustomerPhoneRepository { get; }

    }
}
