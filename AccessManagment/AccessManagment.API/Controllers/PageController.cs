using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AccessManagment.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PageController : Base.ControllerBase
    {
        public PageController(IMediator mediator, InternalLogger _logger) : base(mediator, _logger)
        {
        }

        #region GetAll

        [HttpGet("GetAll")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.PageInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>>
            GetAllAsync()
        {
            FluentResults.Result<List<Domain.Entities.PageInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.PageInfoTbl>>();

            AccessManagment.Application.PageInfo.Commands.GetAllPageInfoCommand command =
                new AccessManagment.Application.PageInfo.Commands.GetAllPageInfoCommand();

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

        #region GetById

        [HttpPost("GetById")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.PageInfoTbl>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.PageInfoTbl>>>
            GetByIdAsync([FromBody] AccessManagment.Application.PageInfo.Commands.GetByIdPageInfoCommand command)
        {
            FluentResults.Result<Domain.Entities.PageInfoTbl> result =
                new FluentResults.Result<Domain.Entities.PageInfoTbl>();

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

        #region GetByApplicationId

        [HttpPost("GetByApplicationId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.PageInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>>
            GetByApplicationIdAsync([FromBody] AccessManagment.Application.PageInfo.Commands.GetByApplicationPageInfoCommand command)
        {
            FluentResults.Result<List<Domain.Entities.PageInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.PageInfoTbl>>();

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

        #region GetByApplicationIdParents

        [HttpPost("GetByApplicationIdParents")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.PageInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>>
            GetByApplicationIdParentsAsync([FromBody] AccessManagment.Application.PageInfo.Commands.GetByApplicationPageInfoCommand command)
        {
            FluentResults.Result<List<Domain.Entities.PageInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.PageInfoTbl>>();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    if(result.Value!=null && result.Value.Count>0)
                    {
                        var items = result.Value.Where(p => p.ParentId == 0 || p.ParentId == null).ToList();

                        result.WithValue(items);
                    }
                    
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

        #region GetByParentId

        [HttpPost("GetByParentId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.PageInfoTbl>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>>
            GetByParentIdAsync([FromBody] AccessManagment.Application.PageInfo.Commands.GetByParentPageInfoCommand command)
        {
            FluentResults.Result<List<Domain.Entities.PageInfoTbl>> result =
                new FluentResults.Result<List<Domain.Entities.PageInfoTbl>>();

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
            UpdateAsync([FromBody] AccessManagment.Application.PageInfo.Commands.UpdatePageInfoCommand command)
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
            CreateAsync([FromBody] AccessManagment.Application.PageInfo.Commands.CreatePageInfoCommand command)
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

        #region Delete

        [HttpPost("Delete")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateAsync([FromBody] AccessManagment.Application.PageInfo.Commands.DeletePageInfoCommand command)
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
    }
}
