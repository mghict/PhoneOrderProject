using BehsamFramework.DapperDomain;
using SettingManagment.Domain.IRepositories;
using SettingManagment.Domain.IRepositories.Area;
using SettingManagment.Domain.IRepositories.Category;
using SettingManagment.Domain.IRepositories.InActive;
using SettingManagment.Domain.IRepositories.Product;
using SettingManagment.Domain.IRepositories.Store;
using SettingManagment.Domain.IRepositories.TimeSheet;
using SettingManagment.Persistence.Repositories.AttributeStatus;
using SettingManagment.Persistence.Repositories.CustomerValues;

namespace SettingManagment.Persistence
{
    public class QueryUnitOfWork :BehsamFramework.DapperDomain.QueryUnitOfWork , IQueryUnitOfWork
    {
        public QueryUnitOfWork(Options options) : base(options)
        {
        }

        private IQueryCustomerValuesRepository _customerValuesQueryRepository;
        public IQueryCustomerValuesRepository CustomerValuesQueryRepository =>
            _customerValuesQueryRepository = _customerValuesQueryRepository ?? new Repositories.CustomerValues.QueryCustomerValuesRepository(IDbConnection);


        private ITimeSheetQueryRepository _timeSheetQueryRepository;
        public ITimeSheetQueryRepository TimeSheetQueryRepository =>
            _timeSheetQueryRepository = _timeSheetQueryRepository ?? new Repositories.TimeSheet.TimeSheetQueryRepository(IDbConnection);

        private IStoreQueryRepository _storeQueryRepository;
        public IStoreQueryRepository StoreQueryRepository =>
            _storeQueryRepository = _storeQueryRepository ?? new Repositories.Store.StoreQueryRepository(IDbConnection);

        private ICategoryQueryRepository _categoryQueryRepository;
        public ICategoryQueryRepository CategoryQueryRepository =>
            _categoryQueryRepository = _categoryQueryRepository ?? new Repositories.Category.CategoryQueryRepository(IDbConnection);

        private IProductQueryRepository _productQueryRepository;
        public IProductQueryRepository ProductQueryRepository =>
            _productQueryRepository = _productQueryRepository ?? new Repositories.Product.ProductQueryRepository(IDbConnection);


        private ICustomeTimeSheetQueryRepository _CustomeTimeSheetQueryRepository;
        public ICustomeTimeSheetQueryRepository CustomeTimeSheetQueryRepository =>
            _CustomeTimeSheetQueryRepository = _CustomeTimeSheetQueryRepository ?? new Repositories.TimeSheet.CustomeTimeSheetQueryRepository(IDbConnection);

        private IInActiveQueryRepository _InActiveQueryRepository;
        public IInActiveQueryRepository InActiveQueryRepository =>
            _InActiveQueryRepository = _InActiveQueryRepository ?? new Repositories.InActive.InActiveQueryRepository(IDbConnection);


        private IStoreInActiveQueryRepository _StoreInActiveQueryRepository;
        public IStoreInActiveQueryRepository StoreInActiveQueryRepository =>
            _StoreInActiveQueryRepository = _StoreInActiveQueryRepository ?? new Repositories.InActive.StoreInActiveQueryRepository(IDbConnection);


        private IAreaInfoQueryRepository _AreaInfoQueryRepository;
        public IAreaInfoQueryRepository AreaInfoQueryRepository =>
            _AreaInfoQueryRepository = _AreaInfoQueryRepository ?? new Repositories.Area.AreaInfoQueryReposiroty(IDbConnection);

        private IProvinceQueryRepository _provinceQueryRepository;
        public IProvinceQueryRepository ProvinceQueryRepository =>
            _provinceQueryRepository = _provinceQueryRepository ?? new Repositories.Area.ProvinceQueryRepository(IDbConnection);

        private ICityQueryRepository _cityQueryRepository;
        public ICityQueryRepository CityQueryRepository =>
            _cityQueryRepository = _cityQueryRepository ?? new Repositories.Area.CityQueryRepository(IDbConnection);

        private IAreaGeoQueryRepository _areaGeoQueryRepository;
        public IAreaGeoQueryRepository AreaGeoQueryRepository =>
            _areaGeoQueryRepository = _areaGeoQueryRepository ?? new Repositories.Area.AreaGeoQueryRepository(IDbConnection);


        private IStoreShippingAreaQueryRepository _storeShippingAreaQueryRepository;
        public IStoreShippingAreaQueryRepository StoreShippingAreaQueryRepository =>
            _storeShippingAreaQueryRepository = _storeShippingAreaQueryRepository ?? new Repositories.Store.StoreShippingAreaQueryRepository(IDbConnection);


        private IStoreShippingQueryRepository _storeShippingQueryRepository;
        public IStoreShippingQueryRepository StoreShippingQueryRepository =>
            _storeShippingQueryRepository = _storeShippingQueryRepository ?? new Repositories.Store.StoreShippingQueryRepository(IDbConnection);
    }
}