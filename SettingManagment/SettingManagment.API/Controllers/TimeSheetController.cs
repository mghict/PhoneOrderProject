using BehsamFreamwork.Logger;
using Framework.MessageSender;
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
        public TimeSheetController(IMediator mediator, InternalLogger _logger, SendMessages logData) : base(mediator, _logger, logData)
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

        #region UpdateTimeSheet

        [HttpPost("UpdateTimeSheet")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UpdateTimeSheetAsync([FromBody] Application.TimeSheetFeature.Commands.UpdateTimeSheetCommand command)
        {

            FluentResults.Result result =
                new FluentResults.Result();
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
                return BadRequest(result);
            }
        }

        #endregion

        #region GetAllTimeSheet

        [HttpPost("GetAllTimeSheet")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>>>
            GetAllTimeSheetAsync([FromBody] Application.TimeSheetFeature.Commands.GetAllTimeSheetCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>();
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
