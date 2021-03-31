using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LogManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController():base()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = string.Format("Service {0} is Available .....",
                ControllerContext.ActionDescriptor.ControllerName//,
                //ControllerContext.ActionDescriptor.ActionName
            );

            return Ok(result);
        }
    }

    
}
