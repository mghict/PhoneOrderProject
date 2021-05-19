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
    public class StoreController :
        Base.ControllerBase
    {
        public StoreController(IMediator mediator, InternalLogger _logger, SendMessages logData) : base(mediator, _logger, logData)
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

        #region GetProducts

        [HttpPost("GetProducts")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.ProductsModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.ProductsModel>>>
            GetProductsAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductsCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.ProductsModel> result =
                new FluentResults.Result<BehsamFramework.Models.ProductsModel>();
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

        #region GetProductsAll

        [HttpPost("GetProductsAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.ProductsModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.ProductsModel>>>
            GetProductsAllAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductsAllCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.ProductsModel> result =
                new FluentResults.Result<BehsamFramework.Models.ProductsModel>();
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

        #region GetProductsAllByStore

        [HttpPost("GetProductsAllByStore")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.ProductsModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.ProductsModel>>>
            GetProductsAllByStoreAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductsAllByStoreCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.ProductsModel> result =
                new FluentResults.Result<BehsamFramework.Models.ProductsModel>();
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

        #region GetCategories

        [HttpPost("GetCategories")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.CategoriesModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.ProductsModel>>>
            GetCategoriesAsync([FromBody] Application.CustomerValuesFeature.Commands.GetCategoriesCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.CategoriesModel> result =
                new FluentResults.Result<BehsamFramework.Models.CategoriesModel>();
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

        #region GetStorePagination

        [HttpPost("GetStorePagination")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.StoreInfoListModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.StoreInfoListModel>>>
            GetStorePaginationAsync([FromBody] Application.StoreFeature.Commands.StoreInfoPaginationCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.StoreInfoListModel> result =
                new FluentResults.Result<BehsamFramework.Models.StoreInfoListModel>();
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

        #region GetProductsReserve

        [HttpPost("GetProductsReserve")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<BehsamFramework.Models.ProductReserveModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<BehsamFramework.Models.ProductReserveModel>>>
            GetProductsReserveAsync([FromBody] Application.CustomerValuesFeature.Commands.GetProductReserveCommand command)
        {

            FluentResults.Result<BehsamFramework.Models.ProductReserveModel> result =
                new FluentResults.Result<BehsamFramework.Models.ProductReserveModel>();
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
