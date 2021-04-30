using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Framework.MessageSender;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagment.API.Controllers
{
    public class OrderController : Base.ControllerBase
    {
        public OrderController(IMediator mediator, InternalLogger _logger, SendMessages _logData) : base(mediator, _logger, _logData)
        {
        }


        #region Create

        [HttpPost("create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateAsync([FromBody] Application.OrderInfoFeature.Commands.CreateOrderCommand command)
        {
            FluentResults.Result result =
                new FluentResults.Result();
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

        #region GetSummeryOrderByDate

        [HttpPost("GetSummeryOrderByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>>>
            GetSummeryOrderByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>();
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

        #region GetSummeryOrderStatusByDate

        [HttpPost("GetSummeryOrderStatusByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>>>
            GetSummeryOrderStatusByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderStatusByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>();
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

        #region GetSummeryOrderStatusDetailsByDate

        [HttpPost("GetSummeryOrderStatusDetailsByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>>>
            GetSummeryOrderStatusDetailsByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderStatusDetailsByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>();
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

        #region GetOrderDetailsByUserId

        [HttpPost("GetOrderDetailsByUserId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>>>
            GetOrderDetailsByUserIdAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderDetailsByUserIdCommand command)
        {
            FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>> result =
                new FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>();
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

        #region GetOrderInfoWithItems

        [HttpPost("GetOrderInfoWithItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>>>
            GetOrderInfoWithItemsAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderInfoWithItemsCommand command)
        {
            FluentResults.Result<Domain.Entities.GetOrderInfoWithItems> result =
                new FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>();
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

        #region ChangeOrderStatus

        [HttpPost("ChangeOrderStatus")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            ChangeOrderStatusAsync([FromBody] Application.OrderInfoFeature.Commands.ChangeOrderStatusCommand command)
        {
            FluentResults.Result result =
                new FluentResults.Result();

            string action = ControllerContext.ActionDescriptor.ActionName;

            try
            {
                await SendForLog(command,LogLevel.Information, action, "Input");

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    await SendDataForLog(command, action, "CustomerPreOrderInfoTbl", command.OrderCode);
                    
                    await SendForLog(command, LogLevel.Information, action, "Result is success");

                    
                    return Ok(value: result);
                }
                else
                {
                    await SendForLog(command, LogLevel.Error, action, "Result Has error:"+ string.Join(",", result.Errors));
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                await SendForLog(command, LogLevel.Error, action, "Exception error:" + ex.Message);
                return BadRequest(error: result);
            }


        }

        #endregion
    }
}
