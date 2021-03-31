using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SettingManagment.Application.CustomerValuesFeature.Commands;

namespace SettingManagment.API.Controllers
{
    public class CustomerValuesController:Base.ControllerBase
    {
        public CustomerValuesController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region GetCustomerGroup

        [HttpGet("GetCustomerGroup")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerGroupAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command = 
                new CustomerValuesCommand()
            {
                Id = 1
            };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
                
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

        #region GetCustomerType

        [HttpGet("GetCustomerType")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerTypeAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command =
                new CustomerValuesCommand()
            {
                Id = 2
            };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
                
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

        #region GetCustomerRegisterType

        [HttpGet("GetCustomerRegisterType")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerRegisterTypeAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command =
                new CustomerValuesCommand()
                {
                    Id = 3
                };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
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

        #region GetCustomerSex

        [HttpGet("GetCustomerSex")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerSexAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command =
                new CustomerValuesCommand()
                {
                    Id = 4
                };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
                
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

        #region GetCustomerJob

        [HttpGet("GetCustomerJob")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerJobAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command =
                new CustomerValuesCommand()
                {
                    Id = 5
                };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
                
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

        #region GetCustomerEducation

        [HttpGet("GetCustomerEducation")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.CustomerAttribute>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.CustomerAttribute>>>
            GetCustomerEducationAsync()
        {
            Application.CustomerValuesFeature.Commands.CustomerValuesCommand command =
                new CustomerValuesCommand()
                {
                    Id = 6
                };

            FluentResults.Result<Domain.Entities.CustomerAttribute> result =
                new FluentResults.Result<Domain.Entities.CustomerAttribute>();
            try
            {
                result = await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }
            finally
            {
                
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

        #region GetAttributeStatus

        [HttpGet("GetAttributeStatus")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.AttributeStatus>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.AttributeStatus>>>>
            GetAttributeStatusAsync()
        {
            Application.CustomerValuesFeature.Commands.AttributeStatusCommand command =
                new AttributeStatusCommand();

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
            finally
            {

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
