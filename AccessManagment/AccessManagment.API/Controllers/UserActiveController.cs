using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserActiveController : Base.ControllerBase
    {
        public UserActiveController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region Create

        [HttpPost("Create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<long>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<long>>>
            CreateAsync([FromBody] AccessManagment.Application.UserActive.Commands.CreateUserActiveCommands command)
        {
            FluentResults.Result<long> result =
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
            UpdateAsync([FromBody] AccessManagment.Application.UserActive.Commands.UpdateUserActiveCommands command)
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

        #region UpdateStatus

        [HttpPost("UpdateStatus")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateStatusAsync([FromBody] AccessManagment.Application.UserActive.Commands.UpdateUserActiveStatusCommands command)
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

        #region GetByUserIdCurrentDate

        [HttpPost("GetByUserIdCurrentDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.UserActiveInfo>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.UserActiveInfo>>>
            GetByUserIdCurrentDateAsync([FromBody] AccessManagment.Application.UserActive.Commands.GetByUserIdCurrentDateCommands command)
        {
            FluentResults.Result<Domain.Entities.UserActiveInfo> result =
                new FluentResults.Result<Domain.Entities.UserActiveInfo>();
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

        #region GetAllUserActiveCurrentDate

        [HttpPost("GetAllUserActiveCurrentDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.UserModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.UserModel>>>
            GetAllUserActiveCurrentDateAsync([FromBody] AccessManagment.Application.UserActive.Commands.GetAllUserActiveCurrentDateCommands command)
        {
            FluentResults.Result<Domain.Entities.UserModel> result =
                new FluentResults.Result<Domain.Entities.UserModel>();
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
