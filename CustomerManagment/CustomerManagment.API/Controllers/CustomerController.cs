using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController:
        Base.ControllerBase
    {
        public CustomerController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region Create

        [HttpPost("create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<long>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<long>>>
            CreateAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.CreateCustomerCommand command)
        {
            FluentResults.Result<long> result =
                new FluentResults.Result<long>();
            try
            {

                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Command is :" + command
                    ).ToSerialize()
                });

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
                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Error,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Exception is: " + ex.Message
                    ).ToSerialize()
                });

                return BadRequest(error: result.ToResult());
            }
            finally
            {
                if (result.IsSuccess)
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Information,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body: "Result: " + result
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
                    });
            }

        }

        #endregion

        #region Remove

        [HttpPost("remove")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result>>
            RemoveAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.DeleteCustomerCommand command)
        {
            FluentResults.Result result =
                new FluentResults.Result();
            try
            {

                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Command is :" + command
                    ).ToSerialize()
                });

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Error,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Exception is: " + ex.Message
                    ).ToSerialize()
                });

                return BadRequest(error: result);
            }
            finally
            {
                if (result.IsSuccess)
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Information,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body: "Result: " + result
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
                    });
            }

        }

        #endregion

        #region Update

        [HttpPost("update")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UpdateAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.UpdateCustomerCommand command)
        {
            FluentResults.Result result =
                new FluentResults.Result();
            try
            {

                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Command is :" + command
                    ).ToSerialize()
                });

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Error,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Exception is: " + ex.Message
                    ).ToSerialize()
                });

                return BadRequest(error: result);
            }
            finally
            {
                if (result.IsSuccess)
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Information,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body: "Result: " + result
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
                    });
            }

        }

        #endregion

        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result>>
            GetByIdAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.GetByIdCustomerCommand command)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>();
            try
            {

                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Command is :" + command
                    ).ToSerialize()
                });

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Error,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Exception is: " + ex.Message
                    ).ToSerialize()
                });

                return BadRequest(error: result);
            }
            finally
            {
                if (result.IsSuccess)
                    await logger.SendToQueue(new InternalLog()
                    {
                        LogLevel = LogLevel.Information,
                        LogMessage = new LogMessage(
                            controllrName: ControllerContext.ActionDescriptor.ControllerName,
                            methodName: ControllerContext.ActionDescriptor.ActionName,
                            userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                            body: "Result: " + result
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
                    });
            }

        }

        #endregion

        #region GetCustomerBySearch

        [HttpPost("GetCustomerBySearch")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result>>
            GetCustomerBySearchAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.GetCustomerBySearchCommand command)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>();
            try
            {

                await logger.SendToQueue(new InternalLog()
                {
                    LogLevel = LogLevel.Information,
                    LogMessage = new LogMessage(
                        controllrName: ControllerContext.ActionDescriptor.ControllerName,
                        methodName: ControllerContext.ActionDescriptor.ActionName,
                        userName: BehsamFramework.Util.Utility.GetUserName(HttpContext),
                        body: "Command is :" + command
                    ).ToSerialize()
                });

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);

                return BadRequest(error: result);
            }
            

        }

        #endregion

        #region GetCustomerInfo

        [HttpPost("GetCustomers")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel>>>
            GetCustomerAsync([FromBody] CustomerManagment.Application.CustomerInfoFeature.Commands.GetAllCustomerCommand command)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(error: result);
            }
            finally
            { }

        }

        #endregion
    }
}
