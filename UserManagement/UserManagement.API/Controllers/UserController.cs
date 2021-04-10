using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController:Base.ControllerBase
    {
        public UserController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        //#region Create

        //[HttpPost("create")]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result<int>),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        //public async
        //    Task<ActionResult<FluentResults.Result<int>>>
        //    CreateAsync([FromBody] UserManagment.Application.UsersFeature.Commands.CreateUserCommand command)
        //{
        //    FluentResults.Result<int> result =
        //        new Result<int>();
        //    try
        //    {

        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Information,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Command is :" + command
        //            ).ToSerialize()
        //        });

        //        result = await Mediator.Send(command);

        //        if (result.IsSuccess)
        //        {
        //            return Ok(value: result);
        //        }
        //        else
        //        {
        //            return BadRequest(error: result.ToResult());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.WithError(ex.Message);
        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Error,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Exception is: " + ex.Message
        //            ).ToSerialize()
        //        });

        //        return BadRequest(error: result.ToResult());
        //    }
        //    finally
        //    {
        //        if (result.IsSuccess)
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Information,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });

        //        else
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Error,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });
        //    }

        //}

        //#endregion

        //#region Remove

        //[HttpPost("remove")]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        //public async
        //    Task<ActionResult<FluentResults.Result>>
        //    RemoveAsync([FromBody] UserManagment.Application.UsersFeature.Commands.DeleteUserCommand command)
        //{
        //    FluentResults.Result result =
        //        new Result();
        //    try
        //    {

        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Information,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Command is :" + command
        //            ).ToSerialize()
        //        });

        //        result = await Mediator.Send(command);

        //        if (result.IsSuccess)
        //        {
        //            return Ok(value: result);
        //        }
        //        else
        //        {
        //            return BadRequest(error: result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.WithError(ex.Message);
        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Error,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Exception is: " + ex.Message
        //            ).ToSerialize()
        //        });

        //        return BadRequest(error: result.ToResult());
        //    }
        //    finally
        //    {
        //        if (result.IsSuccess)
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Information,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });

        //        else
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Error,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });
        //    }

        //}

        //#endregion

        //#region Update

        //[HttpPost("update")]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        //public async
        //    Task<ActionResult<FluentResults.Result>>
        //    UpdateAsync([FromBody] UserManagment.Application.UsersFeature.Commands.UpdateUserCommand command)
        //{
        //    FluentResults.Result result =
        //        new Result();
        //    try
        //    {

        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Information,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Command is :" + command
        //            ).ToSerialize()
        //        });

        //        result = await Mediator.Send(command);

        //        if (result.IsSuccess)
        //        {
        //            return Ok(value: result);
        //        }
        //        else
        //        {
        //            return BadRequest(error: result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.WithError(ex.Message);
        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Error,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Exception is: " + ex.Message
        //            ).ToSerialize()
        //        });

        //        return BadRequest(error: result.ToResult());
        //    }
        //    finally
        //    {
        //        if (result.IsSuccess)
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Information,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });

        //        else
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Error,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });
        //    }

        //}

        //#endregion

        //#region ResetUserPass

        //[HttpPost("reset-user")]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        //public async
        //    Task<ActionResult<FluentResults.Result>>
        //    ResetUserPassAsync([FromBody] UserManagment.Application.UsersFeature.Commands.ResetUserPasswordCommand command)
        //{
        //    FluentResults.Result result =
        //        new Result();
        //    try
        //    {

        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Information,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Command is Encription" 
        //            ).ToSerialize()
        //        });

        //        result = await Mediator.Send(command);

        //        if (result.IsSuccess)
        //        {
        //            return Ok(value: result);
        //        }
        //        else
        //        {
        //            return BadRequest(error: result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.WithError(ex.Message);
        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Error,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Exception is: " + ex.Message
        //            ).ToSerialize()
        //        });

        //        return BadRequest(error: result.ToResult());
        //    }
        //    finally
        //    {
        //        if (result.IsSuccess)
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Information,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });

        //        else
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Error,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });
        //    }

        //}

        //#endregion

        //#region ResetAdminPass

        //[HttpPost("reset-admin")]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        //[ProducesResponseType
        //(type: typeof(FluentResults.Result),
        //    statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        //public async
        //    Task<ActionResult<FluentResults.Result>>
        //    ResetAdminPassAsync([FromBody] UserManagment.Application.UsersFeature.Commands.ResetAdminPasswordCommand command)
        //{
        //    FluentResults.Result result =
        //        new Result();
        //    try
        //    {

        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Information,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Command is Encription"
        //            ).ToSerialize()
        //        });

        //        result = await Mediator.Send(command);

        //        if (result.IsSuccess)
        //        {
        //            return Ok(value: result);
        //        }
        //        else
        //        {
        //            return BadRequest(error: result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.WithError(ex.Message);
        //        await logger.SendToQueue(new InternalLog()
        //        {
        //            LogLevel = LogLevel.Error,
        //            LogMessage = new LogMessage(
        //                controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                methodName: ControllerContext.ActionDescriptor.ActionName,
        //                userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                body: "Exception is: " + ex.Message
        //            ).ToSerialize()
        //        });

        //        return BadRequest(error: result.ToResult());
        //    }
        //    finally
        //    {
        //        if (result.IsSuccess)
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Information,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });

        //        else
        //            await logger.SendToQueue(new InternalLog()
        //            {
        //                LogLevel = LogLevel.Error,
        //                LogMessage = new LogMessage(
        //                    controllrName: ControllerContext.ActionDescriptor.ControllerName,
        //                    methodName: ControllerContext.ActionDescriptor.ActionName,
        //                    userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
        //                    body: "Result: " + result
        //                ).ToSerialize()
        //            });
        //    }

        //}

        //#endregion
    }
}
