using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Services.Order;
using WebSites.Panles.Services.Reports;
using WebSites.Panles.Services.Store;
using WebSites.Panles.Services.TimeSheet;

namespace WebSites.Panles.Services
{
    public interface IOrderFacad
    {
        Services.TimeSheet.IGetTimeSheetService GetTimeSheetService { get; }
        Store.IGetStoreOrderService GetStoreOrderService { get; }
        Store.IGetCategoryByParentService GetCategoryByParentService { get; }
        Store.IGetProductByCategoryService GetProductByCategoryService { get; }
        Store.IGetProductByCategoryAndStoreService GetProductByCategoryAndStoreService { get; }
        Order.ICachedOrderService CachedOrderService { get; }
        Order.ICreateOrderService CreateOrderService { get; }
        Reports.IReportsService ReportsService { get; }
    }

    public class OrderFacad :Base.ServiceBase, IOrderFacad
    {
        private Services.TimeSheet.IGetTimeSheetService getTimeSheetService;
        private Services.Store.IGetStoreOrderService getStoreOrderService;
        private IGetCategoryByParentService getCategoryByParentService;
        private IGetProductByCategoryService getProductByCategoryService;
        private IGetProductByCategoryAndStoreService getProductByCategoryAndStoreService;
        private ICachedOrderService cachedOrderService;
        private ICreateOrderService _CreateOrderService;
        private IReportsService _ReportsService;
        public OrderFacad(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public IGetTimeSheetService GetTimeSheetService =>
            getTimeSheetService = getTimeSheetService ?? new TimeSheet.GetTimeSheetService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public Store.IGetStoreOrderService GetStoreOrderService=>
            getStoreOrderService= getStoreOrderService?? new Store.GetStoreOrderService(CacheService, ServiceCaller, ClientFactory, Mapper);

        
        public IGetCategoryByParentService GetCategoryByParentService =>
            getCategoryByParentService= getCategoryByParentService?? new GetCategoryByParentService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public IGetProductByCategoryService GetProductByCategoryService =>
            getProductByCategoryService= getProductByCategoryService?? new GetProductByCategoryService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public IGetProductByCategoryAndStoreService GetProductByCategoryAndStoreService =>
            getProductByCategoryAndStoreService= getProductByCategoryAndStoreService ?? new GetProductByCategoryAndStoreService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public ICachedOrderService CachedOrderService =>
            cachedOrderService= cachedOrderService?? new CachedOrderService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public ICreateOrderService CreateOrderService =>
            _CreateOrderService= _CreateOrderService?? new Order.CreateOrderService(CacheService, ServiceCaller, ClientFactory, Mapper);

        public IReportsService ReportsService =>
            _ReportsService= _ReportsService?? new Reports.ReportsService(CacheService, ServiceCaller, ClientFactory, Mapper);
    }
}
