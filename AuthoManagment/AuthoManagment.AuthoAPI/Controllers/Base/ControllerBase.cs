using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MassTransit;
using MassTransit.Registration;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ;
using LogLevel = AuthoManagment.Application.Models.LogLevel;
using Microsoft.Extensions.Caching.Memory;

namespace AuthoManagment.AuthoAPI.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected InternalLogger logger;
        private readonly IMemoryCache _cache;
        public ControllerBase(MediatR.IMediator mediator, InternalLogger _logger,IMemoryCache memoryCache)
        {
            Mediator = mediator;
            logger = _logger;
            _cache = memoryCache;
        }

        protected MediatR.IMediator Mediator { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = string.Format("Service {0} is Available .....",
                ControllerContext.ActionDescriptor.ControllerName//,
                //ControllerContext.ActionDescriptor.ActionName
            );


            await logger.SendToQueue(new InternalLog()
            {
                LogLevel = BehsamFreamwork.Logger.LogLevel.Information,
                LogMessage = new BehsamFreamwork.Logger.LogMessage(
                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
                    methodName: ControllerContext.ActionDescriptor.ActionName,
                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext) ,
                    body: "Get is Run"
                ).ToSerialize()
            });

            return Ok(result);
        }

        //private ConnectionFactory _connectionFactory;
        //private IModel _model;
        //private IConnection Connection { get; set; }
        //private void CreateConnection()
        //{
        //    _connectionFactory = new ConnectionFactory()
        //    {
        //        HostName = "localhost",
        //        Password = "admin",
        //        UserName = "admin",
        //        Port = Protocols.DefaultProtocol.DefaultPort
        //    };

        //    Connection = _connectionFactory.CreateConnection();
        //    _model = Connection.CreateModel();
        //    _model.QueueDeclare("UserTest", true, false, false, null);
        //}
    }
}
