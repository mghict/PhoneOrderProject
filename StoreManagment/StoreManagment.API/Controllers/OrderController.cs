using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagment.API.Controllers
{
    public class OrderController : Base.ControllerBase
    {
        public OrderController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
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

        #region GetSummeryOrderStatusByDate

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
    }
}
