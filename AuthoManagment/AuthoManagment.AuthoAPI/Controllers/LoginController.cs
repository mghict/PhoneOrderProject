using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthoManagment.Application.LoginFeature.Command;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using BehsamFramework.Entity;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BehsamFreamwork.Logger;
using Microsoft.Extensions.Caching.Memory;
using LogLevel = BehsamFreamwork.Logger.LogLevel;

namespace AuthoManagment.AuthoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Base.ControllerBase
    {

        public LoginController(IMediator mediator, InternalLogger logger,IMemoryCache _cache) : base(mediator,logger,_cache)
        {
            
        }

        [HttpPost("login-async")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async 
            Task<ActionResult<FluentResults.Result<BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token>>>
            LoginAsync([FromBody] Application.LoginFeature.Command.LoginCommand command)
        {
            FluentResults.Result<Token> result =
                new Result<Token>();
            try
            {

                /*await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body:"Command is :"+ command
                    ).ToSerialize()
                });*/

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                /*await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Error,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Exception is: "+ ex.Message
                    ).ToSerialize()
                });*/

                return BadRequest(error: result.ToResult());
            }
            finally
            {
                /*if(result.IsSuccess)
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Information,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body:"Result: "+ result
                        ).ToSerialize()
                    });

                else
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Error,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body: "Result: " + result
                        ).ToSerialize()
                    });*/
            }
            
        }
    }

    
}
