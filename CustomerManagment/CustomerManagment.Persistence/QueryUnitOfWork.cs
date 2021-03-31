using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.DapperDomain;
using CustomerManagment.Domain.IRepository.CustomerAddress;
using CustomerManagment.Domain.IRepository.CustomerInfo;
using CustomerManagment.Domain.IRepository.CustomerPhone;
using CustomerManagment.Persistence.Repositories.CustomerAddress;
using CustomerManagment.Persistence.Repositories.CustomerInfo;
using CustomerManagment.Persistence.Repositories.CustomerPhone;

namespace CustomerManagment.Persistence
{
    public class QueryUnitOfWork:
        BehsamFramework.DapperDomain.QueryUnitOfWork,
        IQueryUnitOfWork
    {
        private ICustomerQueryRepository _customerRepository;
        private ICustomerAddressQueryRepository _customerAddressRepository;
        public ICustomerPhoneQueryRepository _customerPhoneRepository;

        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        public ICustomerQueryRepository CustomerRepository =>
            _customerRepository = _customerRepository ?? new CustomerInfoQueryRepository(IDbConnection);

        public ICustomerAddressQueryRepository CustomerAddressRepository =>
            _customerAddressRepository =
                _customerAddressRepository ?? new CustomerAddressQueryRepository(IDbConnection);

        public ICustomerPhoneQueryRepository CustomerPhoneRepository =>
            _customerPhoneRepository = _customerPhoneRepository ?? new CustomerPhoneQueryRepository(IDbConnection);
    }
}
