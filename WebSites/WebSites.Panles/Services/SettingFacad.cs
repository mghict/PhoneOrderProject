using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Services.Area;
using WebSites.Panles.Services.InActive;
using WebSites.Panles.Services.Store;
using WebSites.Panles.Services.TimeSheet;

namespace WebSites.Panles.Services
{
    public interface ISettingFacad
    {
        TimeSheet.IGetTimeSheetService GetTimeSheetService { get; }
        TimeSheet.ITimeSheetService TimeSheetService { get; }
        InActive.IInActive InActiveService { get; }
        Store.ICategoryService CategoryService { get; }
        Store.IProductService ProductService { get; }
        Area.IAreaInfoService AreaInfoService { get; }
        Area.ICityAndProvinceService CityAndProvinceService { get; }
        Store.IStoreShippingService StoreShippingService { get; }
    }
    public class SettingFacad :Base.ServiceBase, ISettingFacad
    {
        public SettingFacad(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }


        private IGetTimeSheetService _getTimeSheetService;
        public IGetTimeSheetService GetTimeSheetService =>
            _getTimeSheetService = _getTimeSheetService ?? new TimeSheet.GetTimeSheetService(CacheService, ServiceCaller, ClientFactory, Mapper);


        private ITimeSheetService _timeSheetService;
        public ITimeSheetService TimeSheetService =>
            _timeSheetService= _timeSheetService?? new TimeSheet.TimeSheetService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private IInActive _InActiveService;
        public IInActive InActiveService =>
            _InActiveService= _InActiveService?? new InActive.InActiveService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private ICategoryService _CategoryService;
        public ICategoryService CategoryService =>
            _CategoryService= _CategoryService ?? new CategoryService(CacheService, ServiceCaller, ClientFactory, Mapper);

        
        private IProductService _ProductService;
        public IProductService ProductService =>
            _ProductService = _ProductService?? new Store.ProductService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private IAreaInfoService _areaInfoService;
        public IAreaInfoService AreaInfoService =>
            _areaInfoService= _areaInfoService ?? new Area.AreaInfoService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private ICityAndProvinceService _cityAndProvinceService;
        public ICityAndProvinceService CityAndProvinceService =>
            _cityAndProvinceService= _cityAndProvinceService?? new Area.CityAndProvinceService(CacheService, ServiceCaller, ClientFactory, Mapper);

        private IStoreShippingService _storeShippingService;
        public IStoreShippingService StoreShippingService =>
            _storeShippingService= _storeShippingService?? new Store.StoreShippingService(CacheService, ServiceCaller, ClientFactory, Mapper);
    }
}
