using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagment.API.Controllers
{
    public class ApplicationController : Base.ControllerBase
    {
        private Persistence.IUnitOfWork unitOfWork;
        public ApplicationController(Persistence.IUnitOfWork UnitOfWork, MediatR.IMediator _mediator, InternalLogger _logger) : base(_mediator, _logger)
        {
            unitOfWork = UnitOfWork;
        }

        #region Update

        [HttpPost("Update")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UpdateAsync([FromBody] AccessManagment.Application.ApplicationInfo.Commands.UpdateApplicationInfoCommand command)
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

        #region GetAll

        [HttpGet("GetAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.ApplicationInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.ApplicationInfoTbl>>>>
            GetAllAsync()
        {
            FluentResults.Result< List < Domain.Entities.ApplicationInfoTbl >> result =
                new FluentResults.Result<List<Domain.Entities.ApplicationInfoTbl>>();

            AccessManagment.Application.ApplicationInfo.Commands.GetAllApplicationInfoCommand command =
                new AccessManagment.Application.ApplicationInfo.Commands.GetAllApplicationInfoCommand();

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
