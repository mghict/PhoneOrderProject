using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingManagment.API.Controllers
{
    public class TimeSheetController :
        Base.ControllerBase
    {
        public TimeSheetController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region GetTimeSheet

        [HttpPost("GetTimeSheet")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.TimeSheetTableModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.TimeSheetTableModel>>>>
            GetTimeSheetAsync([FromBody] Application.CustomerValuesFeature.Commands.GetTimeSheetCommand command)
        {

            FluentResults.Result<List<BehsamFramework.Models.TimeSheetTableModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.TimeSheetTableModel>>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ToResult());
            }
        }

        #endregion
    }
}
