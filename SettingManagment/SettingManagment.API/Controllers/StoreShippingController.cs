using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Framework.MessageSender;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SettingManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreShippingController : Base.ControllerBase
    {
        public StoreShippingController(IMediator mediator, InternalLogger _logger, SendMessages logData) : base(mediator, _logger, logData)
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
                SendDataForLog(command, "Create", "AreaInfoTbl", result.Value).Start();

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
                SendDataForLog(command, "Update", "AreaInfoTbl", command.Id).Start();
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

        #region UpdateGlobal

        [HttpPost("UpdateGlobal")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateGlobalAsync([FromBody] Application.StoreShippingFeature.Commands.UpdateShippingGlobalCommand command)
        {

            FluentResults.Result result =
                new FluentResults.Result();
            try
            {
                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    await SendDataForLog(command, "Update", "StoreGeneralShippingTbl", 1);
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
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

        #region GetByIdGlobal

        [HttpPost("GetByIdGlobal")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl>>>
            GetByIdGlobalAsync([FromBody] Application.StoreShippingFeature.Commands.GetShippingGlobalCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl>();
            try
            {
                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.ToResult());
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(result.ToResult());
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

        //-------------------------------------------
        // Global Shipping By Price
        //-------------------------------------------
        #region CreateShippingByPrice

        [HttpPost("CreateShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.CreateShippingGlobalPriceCommand command)
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

        #region UpdateShippingByPrice

        [HttpPost("UpdateShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UpdateShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.UpdateShippingGlobalPriceCommand command)
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

        #region DeleteShippingByPrice

        [HttpPost("DeleteShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            DeleteShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.DeleteShippingGlobalPriceCommand command)
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

        #region GetByIdShippingByPrice

        [HttpPost("GetByIdShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>>>
            GetByIdShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.GetByIdShippingGlobalPriceCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>();
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

        #region GetAllShippingByPrice

        [HttpPost("GetAllShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>>>
            GetAllShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.GetAllShippingGlobalPriceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>();
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

        #region GetRangeShippingByPrice

        [HttpPost("GetRangeShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>>>
            GetRangeShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.GetRangeShippingGlobalPriceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>();
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

        #region GetRangeByAmountShippingByPrice

        [HttpPost("GetRangeByAmountShippingByPrice")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>>>
            GetRangeByAmountShippingByPriceAsync([FromBody] Application.StoreShippingFeature.Commands.GetRangeForAmountShippingGlobalPriceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>();
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


        //-------------------------------------------
        // Global Shipping By Distance
        //-------------------------------------------
        #region CreateShippingByDistance

        [HttpPost("CreateShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.CreateShippingGlobalDistanceCommand command)
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

        #region UpdateShippingByDistance

        [HttpPost("UpdateShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            UpdateShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.UpdateShippingGlobalDistanceCommand command)
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

        #region DeleteShippingByDistance

        [HttpPost("DeleteShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            DeleteShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.DeleteShippingGlobalDistanceCommand command)
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

        #region GetByIdShippingByDistance

        [HttpPost("GetByIdShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>>>
            GetByIdShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.GetByIdShippingGlobalDistanceCommand command)
        {

            FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl>();
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

        #region GetAllShippingByDistance

        [HttpPost("GetAllShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>>>
            GetAllShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.GetAllShippingGlobalDistanceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>();
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

        #region GetRangeShippingByDistance

        [HttpPost("GetRangeShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>>>
            GetRangeShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.GetRangeShippingGlobalDistanceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>();
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

        #region GetRangeByDistanceShippingByDistance

        [HttpPost("GetRangeByDistanceShippingByDistance")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>>>
            GetRangeByDistanceShippingByDistanceAsync([FromBody] Application.StoreShippingFeature.Commands.GetRangeForDistanceShippingGlobalDistanceCommand command)
        {

            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>();
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
