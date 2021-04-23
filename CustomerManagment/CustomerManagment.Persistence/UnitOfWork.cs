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
    public class UnitOfWork:
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        private ICustomerRepository _customerRepository;
        private ICustomerAddressRepository _customerAddressRepository;
        private ICustomerPhoneRepository _customerPhoneRepository;
        public UnitOfWork(Options options) : base(options)
        {
        }

        public ICustomerRepository CustomerRepository =>
            _customerRepository = _customerRepository ?? new Repositories.CustomerInfo.CustomerInfoRepository(IDbConnection);

        public ICustomerAddressRepository CustomerAddressRepository =>
            _customerAddressRepository = _customerAddressRepository ?? new CustomerAddressRepository(IDbConnection);

        public ICustomerPhoneRepository CustomerPhoneRepository =>
            _customerPhoneRepository = _customerPhoneRepository ?? new CustomerPhoneRepository(IDbConnection);

        private IAreaGeoRepository _AreaGeoRepository;
        public IAreaGeoRepository AreaGeoRepository =>
            _AreaGeoRepository = _AreaGeoRepository ?? new Repositories.CustomerAddress.AreaGeoRepository(IDbConnection);


        private ICustomerAddressAreaInfoRepository _CustomerAddressAreaInfoRepository;
        public ICustomerAddressAreaInfoRepository CustomerAddressAreaInfoRepository =>
            _CustomerAddressAreaInfoRepository = _CustomerAddressAreaInfoRepository ?? new Repositories.CustomerAddress.CustomerAddressAreaRepository(IDbConnection);
    }
}
