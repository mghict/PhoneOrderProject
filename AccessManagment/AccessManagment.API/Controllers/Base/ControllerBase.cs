using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagment.API.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected InternalLogger logger;
        protected MediatR.IMediator Mediator { get; }

        public ControllerBase(MediatR.IMediator mediator, InternalLogger _logger)
        {
            Mediator = mediator;
            logger = _logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = string.Format("Service {0} is Available .....",
                ControllerContext.ActionDescriptor.ControllerName
            );


            await logger.SendToQueue(new InternalLog()
            {
                LogLevel = BehsamFreamwork.Logger.LogLevel.Information,
                LogMessage = new BehsamFreamwork.Logger.LogMessage(
                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
                    methodName: ControllerContext.ActionDescriptor.ActionName,
                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                    body: "Get is Run"
                ).ToSerialize()
            });

            return Ok(result);
        }

    }
}
