using DataDapper.Repositories.AreaGeo;
using DataDapper.Repositories.AreaInfo;
using DataDapper.Repositories.CategoryInfo;
using DataDapper.Repositories.CityInfo;
using DataDapper.Repositories.CustomerAddress;
using DataDapper.Repositories.CustomerAttribute;
using DataDapper.Repositories.CustomerAttributeItem;
using DataDapper.Repositories.CustomerInfo;
using DataDapper.Repositories.CustomerPhone;
using DataDapper.Repositories.Product;
using DataDapper.Repositories.Province;
using DataDapper.Repositories.RoleInfo;
using DataDapper.Repositories.StoreArea;
using DataDapper.Repositories.StoreCustomeTimeSheet;
using DataDapper.Repositories.StoreInActive;
using DataDapper.Repositories.StoreInfo;
using DataDapper.Repositories.StoreProduct;
using DataDapper.Repositories.StoreTimeSheet;
using DataDapper.Repositories.UserGeoTrack;
using DataDapper.Repositories.UserInfo;
using DataDapper.Repositories.UserRole;
using DataDapper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IAreaInfoRepository _areaInfoRepository;
        private IAreaGeoRepository _areaGeoRepository;
        private ICityInfoRepository _cityInfoRepository;
        private IProvinceRepository _provinceRepository;
        //------------------------------------------------------------
        private ICustomerAddressRepository _customerAddressRepository;
        private ICustomerAttributeRepository _customerAttributeRepository;
        private ICustomerAttributeItemRepository _customerAttributeItemRepository;
        private ICustomerRepository _customerRepository;
        private ICustomerPhoneRepository _customerPhoneRepository;
        //-----------------------------------------------------------
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IStoreAreaRepository _storeAreaRepository;
        private IStoreRepository _storeRepository;
        private IStoreProductRepository _storeProductRepository;
        private IStoreCustomeTimeSheetRepository _storeCustomeTimeSheetRepository;
        private IStoreTimeSheetRepository _storeTimeSheetRepository;
        private IStoreInActiveRepository _storeInActiveRepository;
        //-------------------------------------------------------------
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUserGeoRepository _userGeoRepository;
        //-------------------------------------------------------------
        public IAreaInfoRepository AreaInfoRepository =>
               _areaInfoRepository= _areaInfoRepository?? new AreaInfoRepository(IDbConnection);

        public IAreaGeoRepository AreaGeoRepository =>
            _areaGeoRepository = _areaGeoRepository ?? new AreaGeoRepository(IDbConnection);

        public ICityInfoRepository CityInfoRepository =>
            _cityInfoRepository= _cityInfoRepository?? new CityRepository(IDbConnection);

        public IProvinceRepository ProvinceRepository => 
            _provinceRepository=_provinceRepository ?? new ProvinceRepository(IDbConnection);

        public ICustomerAddressRepository CustomerAddressRepository =>
            _customerAddressRepository = _customerAddressRepository ?? new CustomerAddressRepository(IDbConnection);

        public ICustomerAttributeRepository CustomerAttributeRepository =>
            _customerAttributeRepository = _customerAttributeRepository ?? new CustomerAttributeRepository(IDbConnection);

        public ICustomerAttributeItemRepository CustomerAttributeItemRepository =>
            _customerAttributeItemRepository = _customerAttributeItemRepository ?? new CustomerAttributeItemRepository(IDbConnection);

        public ICustomerRepository CustomerRepository =>
            _customerRepository = _customerRepository ?? new CustomerRepository(IDbConnection);

        public ICustomerPhoneRepository CustomerPhoneRepository =>
            _customerPhoneRepository = _customerPhoneRepository ?? new CustomerPhoneRepository(IDbConnection);

        public IProductRepository ProductRepository =>
            _productRepository = _productRepository ?? new ProductRepository(IDbConnection);

        public IStoreAreaRepository StoreAreaRepository =>
            _storeAreaRepository = _storeAreaRepository ?? new StoreAreaRepository(IDbConnection);

        public IStoreRepository StoreRepository =>
            _storeRepository = _storeRepository ?? new StoreRepository(IDbConnection);

        public IStoreProductRepository StoreProductRepository =>
            _storeProductRepository = _storeProductRepository ?? new StoreProductRepository(IDbConnection);

        public IStoreCustomeTimeSheetRepository StoreCustomeTimeSheetRepository =>
            _storeCustomeTimeSheetRepository = _storeCustomeTimeSheetRepository ?? new StoreCustomeTimeSheetRepository(IDbConnection);

        public IStoreTimeSheetRepository StoreTimeSheetRepository =>
            _storeTimeSheetRepository = _storeTimeSheetRepository ?? new StoreTimeSheetRepository(IDbConnection);

        public IStoreInActiveRepository StoreInActiveRepository =>
            _storeInActiveRepository = _storeInActiveRepository ?? new StoreInActiveRepository(IDbConnection);

        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository(IDbConnection);

        public IRoleRepository RoleRepository =>
            _roleRepository = _roleRepository ?? new RoleRepository(IDbConnection);

        public IUserRoleRepository UserRoleRepository =>
            _userRoleRepository = _userRoleRepository ?? new UserRoleRepository(IDbConnection);

        public IUserGeoRepository UserGeoRepository =>
            _userGeoRepository = _userGeoRepository ?? new UserGeoRepository(IDbConnection);

        public ICategoryRepository CategoryRepository =>
            _categoryRepository = _categoryRepository ?? new CategoryRepository(IDbConnection);
    }
}
