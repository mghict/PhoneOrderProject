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
    public class InActiveController :
        Base.ControllerBase
    {
        public InActiveController(IMediator mediator, InternalLogger _logger, SendMessages logData) : base(mediator, _logger, logData)
        {
        }


        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.InActiveTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.InActiveTbl>>>
            GetByIdAsync([FromBody] Application.InActiveFeature.Commands.GetByIdInActiveCommand command)
        {

            FluentResults.Result<Domain.Entities.InActiveTbl> result =
                new FluentResults.Result<Domain.Entities.InActiveTbl>();
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

        #region GetAll

        [HttpPost("GetAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.InActiveTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.InActiveTbl>>>>
            GetAllAsync([FromBody] Application.InActiveFeature.Commands.GetAllInActiveCommand command)
        {

            FluentResults.Result<List<Domain.Entities.InActiveTbl>> result =
                new FluentResults.Result<List<Domain.Entities.InActiveTbl>>();
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
            UpdateAsync([FromBody] Application.InActiveFeature.Commands.EditInActiveCommand command)
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

        #region Create

        [HttpPost("Create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateAsync([FromBody] Application.InActiveFeature.Commands.CreateInActiveCommand command)
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

        #region Remove

        [HttpPost("Remove")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            RemoveAsync([FromBody] Application.InActiveFeature.Commands.DeleteInActiveCommand command)
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

        //------------------------------------
        // StoreInActive
        //------------------------------------

        #region Create

        [HttpPost("CreateStoreInActive")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateStoreInActiveAsync([FromBody] Application.InActiveFeature.Commands.CreateStoreInActiveCommand command)
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

        #region Update

        [HttpPost("UpdateStoreInActive")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            StoreInActiveAsync([FromBody] Application.InActiveFeature.Commands.EditStoreInActiveCommand command)
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

        #region Remove

        [HttpPost("RemoveStoreInActive")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            RemoveStoreInActiveAsync([FromBody] Application.InActiveFeature.Commands.DeleteStoreInActiveCommand command)
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

        #region GetById

        [HttpPost("GetByIdStoreInActive")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreInActiveTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.InActiveTbl>>>
            GetByIdStoreInActiveAsync([FromBody] Application.InActiveFeature.Commands.GetByIdStoreInActiveCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreInActiveTbl> result =
                new FluentResults.Result<Domain.Entities.StoreInActiveTbl>();
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

        #region GetAll

        [HttpPost("GetAllStoreInActive")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.InActiveTbl>>>>
            GetAllStoreInActiveAsync([FromBody] Application.InActiveFeature.Commands.GetAllStoreInActiveCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                var sortedList = result.Value.OrderBy(p => p.FromDate).ThenBy(p => p.ToDate).ToList();
                result.WithValue(sortedList);
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
