using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SettingManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreShippingController : Base.ControllerBase
    {
        public StoreShippingController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region Create

        [HttpPost("Create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<int>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<int>>>
            CreateAsync([FromBody] Application.StoreShippingFeature.Commands.CreateStoreShippingCommand command)
        {

            FluentResults.Result<int> result =
                new FluentResults.Result<int>();
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

        #region CreateArea

        [HttpPost("CreateArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<int>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<int>>>
            CreateAreaAsync([FromBody] Application.StoreShippingFeature.Commands.CreateStoreShippingAreaCommand command)
        {

            FluentResults.Result<int> result =
                new FluentResults.Result<int>();
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

        //-----------------------
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
            UpdateAsync([FromBody] Application.StoreShippingFeature.Commands.UpdateStoreShippingCommand command)
        {

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
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

        #region UpdateArea

        [HttpPost("UpdateArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateAreaAsync([FromBody] Application.StoreShippingFeature.Commands.UpdateStoreShippingAreaCommand command)
        {

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
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

        //------------------------
        #region DeleteArea

        [HttpPost("DeleteArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            DeleteAreaAsync([FromBody] Application.StoreShippingFeature.Commands.DeleteStoreShippingAreaCommand command)
        {

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
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

        //------------------------

        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreShippingTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreShippingTbl>>>
            GetByIdAsync([FromBody] Application.StoreShippingFeature.Commands.GetByIdStoreShippingCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreShippingTbl> result =
                new FluentResults.Result<Domain.Entities.StoreShippingTbl>();
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

        #region GetByIdArea

        [HttpPost("GetByIdArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreShippingAreaTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreShippingAreaTbl>>>
            GetByIdAreaAsync([FromBody] Application.StoreShippingFeature.Commands.GetByIdStoreShippingAreaCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreShippingAreaTbl> result =
                new FluentResults.Result<Domain.Entities.StoreShippingAreaTbl>();
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

        //----------------------

        #region GetByStoreId

        [HttpPost("GetByStoreId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreShippingTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreShippingTbl>>>
            GetByStoreIdAsync([FromBody] Application.StoreShippingFeature.Commands.GetByStoreIdStoreShippingCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreShippingTbl> result =
                new FluentResults.Result<Domain.Entities.StoreShippingTbl>();
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

        #region GetByStoreIdArea

        [HttpPost("GetByStoreIdArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>>>
            GetByStoreIdAreaAsync([FromBody] Application.StoreShippingFeature.Commands.GetByStoreIdStoreShippingAreaCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>();
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

        //---------------------
        #region GetAll

        [HttpGet("GetAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreShippingTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreShippingTbl>>>>
            GetAllAsync()
        {
            Application.StoreShippingFeature.Commands.GetAllStoreShippingCommand command =
                new Application.StoreShippingFeature.Commands.GetAllStoreShippingCommand();

            FluentResults.Result<List<Domain.Entities.StoreShippingTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingTbl>>();
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

        #region GetAllArea

        [HttpGet("GetAllArea")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>>>
            GetAllAreaAsync()
        {
            Application.StoreShippingFeature.Commands.GetAllStoreShippingAreaCommand command =
                new Application.StoreShippingFeature.Commands.GetAllStoreShippingAreaCommand();

            FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>();
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
    }
}
