﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagment.API.Controllers
{
    public class CustomerPhoneController :
        Base.ControllerBase
    {
        public CustomerPhoneController(IMediator mediator, IInternalLogger _logger) : base(mediator, _logger)
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
            CreateAsync([FromBody] CustomerManagment.Application.CustomerPhoneFeature.Commands.CreateCustomerPhoneCommand command)
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
            RemoveAsync([FromBody] CustomerManagment.Application.CustomerPhoneFeature.Commands.DeleteCustomerPhoneCommand command)
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
            UpdateAsync([FromBody] CustomerManagment.Application.CustomerPhoneFeature.Commands.UpdateCustomerPhoneCommand command)
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
        (type: typeof(FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel>>>
            GetByIdAsync(Application.CustomerPhoneFeature.Commands.GetByIdCustomerPhoneCommand command)
        {
           /* CustomerManagment.Application.CustomerPhoneFeature.Commands.GetByIdCustomerPhoneCommand command =
                new Application.CustomerPhoneFeature.Commands.GetByIdCustomerPhoneCommand()
                {
                    Id = id
                };*/

            FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel>();
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
            

        }

        #endregion

        #region GetCustomerPhones

        [HttpGet("GetCustomerPhones")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>>>
            GetCustomerPhonesAsync([FromQuery] long id)
        {
            CustomerManagment.Application.CustomerPhoneFeature.Commands.GetCustomerPhonesCommand command =
                new Application.CustomerPhoneFeature.Commands.GetCustomerPhonesCommand()
                {
                    Id = id
                };

            FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>();
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


        }

        #endregion

        #region CreateWithList

        [HttpPost("CreateWithList")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>>>
            CreateWithListAsync([FromBody] CustomerManagment.Application.CustomerPhoneFeature.Commands.CreateCustomerPhoneWithListCommand command)
        {
            FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>();
            try
            {

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

                return BadRequest(error: result.ToResult());
            }
            finally
            {
                   
            }

        }

        #endregion

    }
}