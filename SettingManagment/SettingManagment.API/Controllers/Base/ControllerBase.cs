using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Microsoft.AspNetCore.Mvc;
using BehsamFramework.Utility;

namespace SettingManagment.API.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected InternalLogger logger;
        protected Framework.MessageSender.SendMessages loggerData;
        public ControllerBase(MediatR.IMediator mediator, InternalLogger _logger, Framework.MessageSender.SendMessages logData)
        {
            Mediator = mediator;
            logger = _logger;
            loggerData = logData;
        }

        protected MediatR.IMediator Mediator { get; }

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

        [NonAction]
        protected async Task SendDataForLog<T>(T data,string actionName, string entityName,long entityId)
        {
            Framework.MessageSender.LogMessage logMessage = new Framework.MessageSender.LogMessage()
            {
                CreateDate = System.DateTime.Now,
                Action = actionName,
                Entity=entityName,
                Data=data.ToJsonString(),
                IP=HttpContext.Request.Headers["IP"].ToString()??HttpContext.Connection.RemoteIpAddress.ToString(),
                UserId= Convert.ToInt32(HttpContext.Request.Headers["Id"].ToString()??"0"),
                UserName= HttpContext.Request.Headers["Name"].ToString(),
                Id=entityId
            };

            await loggerData.SendToQueue(logMessage);
            return;
        }
    }
}
