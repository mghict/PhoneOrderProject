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
    
    public class ApplicationController : BaseController
    {
        private Services.IUserFacad _userFacad;
        public ApplicationController(Services.IUserFacad UserFacad,IMemoryCache memoryCache, IHttpClientFactory _clientFactory, ICacheService _cacheService, StaticValues staticValues, IMapper mapper) : base(memoryCache, _clientFactory, _cacheService, staticValues, mapper)
        {
            _userFacad = UserFacad;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _userFacad.ApplicationService.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _userFacad.ApplicationService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Authorize.ApplicationInfoModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var rest =await _userFacad.ApplicationService.Update(model);
                    if(rest.IsSuccess)
                    {
                        return Redirect("/Admin/Application/Index");
                    }

                    ModelState.AddModelError("Error", rest.GetErrors());
                    return View("Update", model);
                }
                else
                {
                    return View("Update", model);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View("Update",model);
            }
            
        }
    }
}
