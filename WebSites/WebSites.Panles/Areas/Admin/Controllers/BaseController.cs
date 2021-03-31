using Microsoft.AspNetCore.Mvc;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        //protected IServiceCaller Service { get; set; }

        public BaseController()//IServiceCaller _service)
        {
            //Service = _service;
        }
    }
}