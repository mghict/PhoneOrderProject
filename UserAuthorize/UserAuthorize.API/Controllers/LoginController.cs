using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserAuthorize.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Base.ControllerBase
    {
        public LoginController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region LoginUser

        [HttpPost("LoginUser")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.LoginModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.LoginModel>>>
            LoginUserAsync([FromBody] Application.UserFeatures.Commands.UserLoginCommand command)
        {
            FluentResults.Result<BehsamFramework.Models.LoginModel> result =
                new FluentResults.Result<BehsamFramework.Models.LoginModel>();
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
          

        }

        #endregion

        #region UserAccess

        [HttpPost("UserAccess")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UserAccessAsync([FromBody] Application.UserFeatures.Commands.UserAccessCommand command)
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
    }
}
