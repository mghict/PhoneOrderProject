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
    public class ProductController : BaseController
    {
        private Services.ISettingFacad _settingFacad;
        public ProductController(
            Services.ISettingFacad SettingFacad,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper, ServiceCaller serviceCaller) : base(serviceCaller,memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _settingFacad = SettingFacad;
        }

        public async Task<IActionResult> Index(string searchKey="",int pageNumber=0,int pageSize=20)
        {
            var model =await _settingFacad.ProductService.GetProductsAllAsync(searchKey, pageNumber, pageSize);
            return View(model);
        }

        public async Task<IActionResult> StoreProductIndex(string storeId, string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            float sId = 0.0f;

            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;
            float.TryParse(storeId, style, info, out sId);

            ViewBag.StoreId = sId.ToString(info);

            var model =await _settingFacad.ProductService.GetProductsAllByStoreAsync(sId,searchKey, pageNumber, pageSize);
            return View(model);
        }
    }
}
