using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Framework.MessageSender;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserActiveController : Base.ControllerBase
    {
        public UserActiveController(IMediator mediator, InternalLogger _logger, SendMessages _logData) : base(mediator, _logger, _logData)
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
            CreateAsync([FromBody] Application.OrderUserActiveFeature.Commands.CreateUserActiveCommand command)
        {
            FluentResults.Result< long> result =
                new FluentResults.Result<long>();
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

        #region Update

        [HttpPost("Update")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateAsync([FromBody] Application.OrderUserActiveFeature.Commands.UpdateUserActiveCommand command)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
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

        #region Delete

        [HttpPost("Delete")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateAsync([FromBody] Application.OrderUserActiveFeature.Commands.DeleteUserActiveCommand command)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
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

        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerPreOrderUserActive>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerPreOrderUserActive>>>
            GetByIdAsync([FromBody] Application.OrderUserActiveFeature.Commands.GetByIdUserActiveCommand command)
        {
            FluentResults.Result<Domain.Entities.CustomerPreOrderUserActive> result =
                new FluentResults.Result<Domain.Entities.CustomerPreOrderUserActive>();
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

        #region GetDetailsByUserId

        [HttpPost("GetDetailsByUserId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>>>
            GetDetailsByUserIdAsync([FromBody] Application.OrderUserActiveFeature.Commands.GetbyUserIdUserCurrentDetailsCommand command)
        {
            FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>> result =
                new FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>();
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

        #region GetSummeryByUserId

        [HttpPost("GetSummeryByUserId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>>>
            GetSummeryByUserIdAsync([FromBody] Application.OrderUserActiveFeature.Commands.GetbyUserIdUserCurrentSummeryCommand command)
        {
            FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> result =
                new FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>();
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

        //------------------------------------
        //------------------------------------

        #region GetUserActivityDetailsInDate

        [HttpPost("GetUserActivityDetailsInDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>>>
            GetUserActivityDetailsInDateAsync([FromBody] Application.OrderUserActiveFeature.Commands.GetUserActivityDetailsInDateCommand command)
        {
            FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>> result =
                new FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>();
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

        #region GetUserActivitySummeryInDate

        [HttpPost("GetUserActivitySummeryInDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>>>
            GetUserActivitySummeryInDateAsync([FromBody] Application.OrderUserActiveFeature.Commands.GetUserActivitySummeryInDateCommand command)
        {
            FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> result =
                new FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>();
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
