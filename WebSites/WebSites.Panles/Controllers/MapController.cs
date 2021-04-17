using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Services.Map;

namespace WebSites.Panles.Controllers
{
    public class MapController : Controller
    {
        private Services.Map.NeshanMapService NeshanMapService;

        public MapController(NeshanMapService neshanMapService)
        {
            this.NeshanMapService = neshanMapService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> SearchMap(string searchKey="",string lat= "32.1592549", string lng= "54.5478664")
        {
            if(string.IsNullOrEmpty( searchKey))
            {
                return Json(new { IsSuccess = false,Message="مقدار جستجو را وارد کنید" }) ;
            }
            else
            {
                var items = await NeshanMapService.SearchApi(searchKey, lat, lng);
                if(items!=null && items.Count>0)
                {
                    var outItems = items.Items.Select(s => new {
                        Title = s.Title ?? "",
                        Address = s.Address ??"",
                        Region = s.Region ?? "",
                        X = s.Location.X,
                        Y = s.Location.Y
                    }).ToList();

                    return Json(new { IsSuccess = true, Items = outItems });
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "اطلاعات یافت نشد" });
                }
            }
        }
    }
}
