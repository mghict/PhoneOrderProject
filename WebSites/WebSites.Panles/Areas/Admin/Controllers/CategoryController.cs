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
    public class CategoryController : BaseController
    {
        private Services.ISettingFacad _settingFacad;
        public CategoryController(
            Services.ISettingFacad SettingFacad,
            IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _settingFacad = SettingFacad;
        }

        public async Task< IActionResult> Index(string searchkey = "",int pageNum=0,int pageSize=20)
        {
            var model =await  _settingFacad.CategoryService.GetCategories(searchkey, pageNum, pageSize);
            return View(model);
        }
    }
}
