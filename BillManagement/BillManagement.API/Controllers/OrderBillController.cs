using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderBillController : Base.ControllerBase
    {
        public OrderBillController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region GetData

        [HttpPost("GetData")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.OrderResponse>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.OrderResponse>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.OrderResponse>>>
            GetDataAsync([FromBody] Application.BillFeature.Commands.GetOrderDetailCommand command)
        {
            FluentResults.Result<Domain.Entities.OrderResponse> result =
                new FluentResults.Result<Domain.Entities.OrderResponse>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    result.WithValue(new Domain.Entities.OrderResponse());
                    return BadRequest(error: result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new Domain.Entities.OrderResponse());
                return BadRequest(error: result);
            }


        }

        #endregion

        #region UpdateData

        [HttpPost("UpdateData")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.OrderRequest>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.OrderRequest>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.OrderRequest>>>
            UpdateDataAsync([FromBody] Application.BillFeature.Commands.UpdateOrderDetailCommand command)
        {
            FluentResults.Result<Domain.Entities.OrderRequest> result =
                new FluentResults.Result<Domain.Entities.OrderRequest>();
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

        #region Login

        [HttpPost("Login")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<string>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<string>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<string>>>
            LoginAsync([FromBody] Application.BillFeature.Commands.LoginUserCommand command)
        {
            FluentResults.Result<string> result =
                new FluentResults.Result<string>();
            try
            {

                result = await Mediator.Send(command);

                return Ok(value: result);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(string.Empty);
                return Ok(result);
            }


        }

        #endregion
    }
}
