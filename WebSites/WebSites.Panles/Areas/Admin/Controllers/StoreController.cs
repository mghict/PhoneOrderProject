using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : BaseController
    {
        private readonly Services.Store.IGetStoreInfoPaginationService storeInfoPaginationService;
        public StoreController(
            Services.Store.IGetStoreInfoPaginationService StoreInfoPaginationService,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            storeInfoPaginationService = StoreInfoPaginationService;
        }

        public async Task< IActionResult > Index(int page = 0,int pagesize = 20,string searchKey="")
        {
            var model=await storeInfoPaginationService.GetStoresAsync(page, pagesize, searchKey);
            if(model==null)
            {
                model = new BehsamFramework.Models.StoreInfoListModel();
                model.RowCount = 0;
                model.Stores = new List<BehsamFramework.Models.StoreOrderModel>();
            }

            return View(model);
        }

        
    }
}
