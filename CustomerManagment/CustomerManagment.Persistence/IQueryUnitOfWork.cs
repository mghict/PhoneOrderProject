using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence
{
    public interface IQueryUnitOfWork : BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepository.CustomerInfo.ICustomerQueryRepository CustomerRepository { get; }
        Domain.IRepository.CustomerAddress.ICustomerAddressQueryRepository CustomerAddressRepository { get; }
        Domain.IRepository.CustomerPhone.ICustomerPhoneQueryRepository CustomerPhoneRepository { get; }
    }
}
