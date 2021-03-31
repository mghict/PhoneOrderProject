using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingManagment.API.Controllers
{
    public class StoreController :
        Base.ControllerBase
    {
        public StoreController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region GetStore

        [HttpPost("GetStore")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.StoreOrderModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.StoreOrderModel>>>>
            GetStoreAsync([FromBody] Application.CustomerValuesFeature.Commands.GetStoreCommand command)
        {

            FluentResults.Result<List<BehsamFramework.Models.StoreOrderModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.StoreOrderModel>>();
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

        #region GetCategory

        [HttpPost("GetCategory")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.CategoryShowModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.CategoryShowModel>>>>
            GetCategoryAsync([FromBody] Application.CustomerValuesFeature.Commands.GetCategoryCommand command)
        {

            FluentResults.Result<List<BehsamFramework.Models.CategoryShowModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.CategoryShowModel>>();
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

        #region GetProductByCategory

        [HttpPost("GetProductByCategory")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>>>
            GetProductByCategoryAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductByCatCommand command)
        {

            FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>();
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

        #region GetProductByCategoryAndStore

        [HttpPost("GetProductByCategoryAndStore")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>>>
            GetProductByCategoryAndStoreAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductByCatAndStoreCommand command)
        {

            FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>> result =
                new FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>();
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
