﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagment.API.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected InternalLogger logger;
        protected MediatR.IMediator Mediator { get; }
        protected Framework.MessageSender.SendMessages loggerData { get; }
        public ControllerBase(MediatR.IMediator mediator, InternalLogger _logger, Framework.MessageSender.SendMessages _logData)
        {
            Mediator = mediator;
            logger = _logger;
            loggerData = _logData;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = string.Format("Service {0} is Available .....",
                ControllerContext.ActionDescriptor.ControllerName
            );

            return Ok(result);
        }


        [NonAction]
        protected async Task SendDataForLog<T>(T data, string actionName, string entityName, long entityId)
        {
            string Id = HttpContext.Request.Headers["Id"].ToString();
            Id = string.IsNullOrEmpty(Id) ? "0" : Id;

            Framework.MessageSender.LogMessage logMessage = new Framework.MessageSender.LogMessage()
            {
                CreateDate = System.DateTime.Now,
                Action = actionName,
                Entity = entityName,
                Data = data.ToJsonString(),
                IP = HttpContext.Request.Headers["IP"].ToString() ?? HttpContext.Connection.RemoteIpAddress.ToString(),
                UserId = Convert.ToInt32(Id),
                UserName = HttpContext.Request.Headers["Name"].ToString(),
                Id = entityId
            };

            await loggerData.SendToQueue(logMessage);
            return;
        }

        [NonAction]
        protected async Task SendForLog<T>(T data, LogLevel lvl, string actionName, string status)
        {
            LogMessage _LogMessage = new LogMessage()
            {
                ControllrName = ControllerContext.ActionDescriptor.ControllerName,
                MethodName = actionName,
                IP = HttpContext.Request.Headers["IP"].ToString() ?? HttpContext.Connection.RemoteIpAddress.ToString(),
                UserId = Convert.ToInt32(HttpContext.Request.Headers["Id"].ToString() ?? "0"),
                UserName = HttpContext.Request.Headers["Name"].ToString(),
                ActionName = actionName,
                CreateDate = System.DateTime.Now,
                Status = status,
                Body = data.ToJsonString(),
            };

            var log = new InternalLog()
            {
                LogLevel = lvl,
                LogMessage = _LogMessage.ToSerialize()
            };

            await logger.SendToQueue(log);

            return;
        }
    }
}
