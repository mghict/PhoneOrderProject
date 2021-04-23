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
    public class AreaController : Base.ControllerBase
    {
        public AreaController(IMediator mediator, InternalLogger _logger, SendMessages logData) : base(mediator, _logger, logData)
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
            CreateAsync([FromBody] Application.AreaFeature.Commands.CreateAreaInfoCommand command)
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
            UpdateAsync([FromBody] Application.AreaFeature.Commands.UpdateAreaInfoCommand command)
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

        #region Delete

        [HttpPost("Delete")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            DeleteAsync([FromBody] Application.AreaFeature.Commands.DeleteAreaInfoCommand command)
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

        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.AreaInfoTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.AreaInfoTbl>>>
            GetByIdAsync([FromBody] Application.AreaFeature.Commands.GetByIdAreaInfoCommand command)
        {

            FluentResults.Result<Domain.Entities.AreaInfoTbl> result =
                new FluentResults.Result<Domain.Entities.AreaInfoTbl>();
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

        #region GetAll

        [HttpGet("GetAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>>>
            GetAllAsync()
        {
            Application.AreaFeature.Commands.GetAllAreaInfoCommand command =
                new Application.AreaFeature.Commands.GetAllAreaInfoCommand();

            FluentResults.Result<List<Domain.Entities.AreaInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>();
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

        #region GetAllAreaType

        [HttpGet("GetAllAreaType")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AttributeStatus>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AttributeStatus>>>>
            GetAllAreaTypeAsync()
        {
            Application.AreaFeature.Commands.GetAllAreaTypeCommand command =
                new Application.AreaFeature.Commands.GetAllAreaTypeCommand();

            FluentResults.Result<List<Domain.Entities.AttributeStatus>> result =
                new FluentResults.Result<List<Domain.Entities.AttributeStatus>>();
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

        #region GetByCity

        [HttpPost("GetByCity")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>>>
            GetByCityAsync([FromBody] Application.AreaFeature.Commands.GetByCityAreaInfoCommand command)
        {
            

            FluentResults.Result<List<Domain.Entities.AreaInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>();
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

        #region GetByParent

        [HttpPost("GetByParent")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>>>
            GetByParentAsync([FromBody] Application.AreaFeature.Commands.GetByParentAreaInfoCommand command)
        {


            FluentResults.Result<List<Domain.Entities.AreaInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.AreaInfoTbl>>();
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

        #region GetAllBySearch

        [HttpPost("GetAllBySearch")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.AreaModel>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.AreaModel>>>
            GetAllBySearchAsync([FromBody] Application.AreaFeature.Commands.GetAllAreaInfoSearchCommand command)
        {


            FluentResults.Result<Domain.Entities.AreaModel> result =
                new FluentResults.Result<Domain.Entities.AreaModel>();
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

        #region GetAllCity

        [HttpGet("GetAllCity")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CityTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CityTbl>>>>
            GetAllCityAsync()
        {
            Application.AreaFeature.Commands.GetAllCityCommand command =
                new Application.AreaFeature.Commands.GetAllCityCommand();

            FluentResults.Result<List<Domain.Entities.CityTbl>> result =
                new FluentResults.Result<List<Domain.Entities.CityTbl>>();
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

        #region GetAllProvince

        [HttpGet("GetAllProvince")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.ProvinceTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.ProvinceTbl>>>>
            GetAllProvinceAsync()
        {
            Application.AreaFeature.Commands.GetAllProvinceCommand command =
                new Application.AreaFeature.Commands.GetAllProvinceCommand();

            FluentResults.Result<List<Domain.Entities.ProvinceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.ProvinceTbl>>();
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

        #region GetAllCityByProvince

        [HttpPost("GetAllCityByProvince")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.CityTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.CityTbl>>>>
            GetAllCityByProvinceAsync([FromBody] Application.AreaFeature.Commands.GetAllCityByProvinceCommand command)
        {


            FluentResults.Result<List<Domain.Entities.CityTbl>> result =
                new FluentResults.Result<List<Domain.Entities.CityTbl>>();
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

        #region CreateAreaGeo

        [HttpPost("CreateAreaGeo")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<int>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<int>>>
            CreateAreaGeoAsync([FromBody] Application.AreaFeature.Commands.CreateAreaGeoCommand command)
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

        #region GetGeoByAreaId

        [HttpPost("GetGeoByAreaId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AreaGeoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AreaGeoTbl>>>>
            GetGeoByAreaIdAsync([FromBody] Application.AreaFeature.Commands.GetByAreaIdAreaGeoCommand command)
        {


            FluentResults.Result<List<Domain.Entities.AreaGeoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.AreaGeoTbl>>();
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
