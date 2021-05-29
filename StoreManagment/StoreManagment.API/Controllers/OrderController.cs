using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using Framework.MessageSender;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagment.API.Controllers
{
    public class OrderController : Base.ControllerBase
    {
        public OrderController(IMediator mediator, InternalLogger _logger, SendMessages _logData) : base(mediator, _logger, _logData)
        {
        }


        #region Create

        [HttpPost("create")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            CreateAsync([FromBody] Application.OrderInfoFeature.Commands.CreateOrderCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<long> result =
                new FluentResults.Result<long>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        var tasklog = SendDataForLog(createDate,command, action, "CustomerPreOrderInfoTbl", command.OrderInfo.OrderCode, command.OrderInfo.OrderState, "ثبت سفارش");
                        //tasklog.Start();

                        string storeId = Math.Round(command.OrderInfo.StoreId, 3).ToString(System.Globalization.CultureInfo.InvariantCulture);
                        var tasklogOrder = SendDataForOrderLog(createDate,"ثبت سفارش توسط کاربر کال سنتر در شعبه" + storeId, command.OrderInfo.Id, command.OrderInfo.OrderCode, command.OrderInfo.Detail.UserId);

                        //tasklogOrder.Start();

                        Task.WaitAll(tasklog, tasklogOrder);
                    }
                    catch
                    {

                    }
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);

                return BadRequest(error: result.ToResult());
            }
            

        }

        #endregion

        #region GetSummeryOrderByDate

        [HttpPost("GetSummeryOrderByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>>>
            GetSummeryOrderByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>();
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

        #region GetSummeryOrderStatusByDate

        [HttpPost("GetSummeryOrderStatusByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>>>
            GetSummeryOrderStatusByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderStatusByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>();
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

        #region GetSummeryOrderStatusDetailsByDate

        [HttpPost("GetSummeryOrderStatusDetailsByDate")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>>>
            GetSummeryOrderStatusDetailsByDateAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrderStatusDetailsByDate command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>();
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

        #region GetOrderDetailsByUserId

        [HttpPost("GetOrderDetailsByUserId")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>>>
            GetOrderDetailsByUserIdAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderDetailsByUserIdCommand command)
        {
            FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>> result =
                new FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>();
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

        #region GetOrderInfoWithItems

        [HttpPost("GetOrderInfoWithItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>>>
            GetOrderInfoWithItemsAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderInfoWithItemsCommand command)
        {
            FluentResults.Result<Domain.Entities.GetOrderInfoWithItems> result =
                new FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>();
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

        #region GetSummeryOrdersByDateAndStore

        [HttpPost("GetSummeryOrdersByDateAndStore")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>>>
            GetSummeryOrdersByDateAndStoreAsync([FromBody] Application.OrderInfoFeature.Commands.GetSummeryOrdersByDateAndStore command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>();
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

        #region GetDetailsOrdersByDateAndStore

        [HttpPost("GetDetailsOrdersByDateAndStore")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>>>
            GetDetailsOrdersByDateAndStoreAsync([FromBody] Application.OrderInfoFeature.Commands.GetDetailsOrdersByDateAndStore command)
        {
            FluentResults.Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>> result =
                new FluentResults.Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>();
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

        #region ChangeOrderStatus

        [HttpPost("ChangeOrderStatus")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            ChangeOrderStatusAsync([FromBody] Application.OrderInfoFeature.Commands.ChangeOrderStatusCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result result =
                new FluentResults.Result();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;

                        var tasklog = SendDataForLog(createDate,command, action, "CustomerPreOrderInfoTbl", command.OrderCode, command.Status, command.Reason);
                        var tasklogOrder = SendDataForOrderLog(createDate,command.Reason, 0, command.OrderCode, 0);

                        Task.WaitAll(tasklog, tasklogOrder);
                        
                    }
                    catch
                    {

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
                //await SendForLog(command, LogLevel.Error, action, "Exception error:" + ex.Message);
                return BadRequest(error: result);
            }


        }

        #endregion

        //----------------------------------
        //----------------------------------

        #region AcceptUserForOrderItems

        [HttpPost("AcceptUserForOrderItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            AcceptUserForOrderItemsAsync([FromBody] Application.OrderInfoFeature.Commands.AcceptUserForOrderItemsCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        string reason = "تایید کالا";
                        int status = 6;
                        var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemTbl", command.OrderId,status,reason );
                        var tasklogOrder = SendDataForOrderLog(createDate, reason, command.OrderId,0, 0);

                        Task.WaitAll(tasklog, tasklogOrder);

                    }
                    catch
                    {

                    }

                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        #region FirstStateUserForOrderItems

        [HttpPost("FirstStateUserForOrderItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            FirstStateUserForOrderItemsAsync([FromBody] Application.OrderInfoFeature.Commands.FirstStateUserForOrderItemsCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        string reason = "برگشت کالا به تخصیص نیافته";
                        int status = 1;
                        var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemTbl", command.OrderId, status, reason);
                        var tasklogOrder = SendDataForOrderLog(createDate, reason, command.OrderId, 0, 0);

                        Task.WaitAll(tasklog, tasklogOrder);

                    }
                    catch
                    {

                    }

                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        #region ReplaceStateUserForOrderItems

        [HttpPost("ReplaceStateUserForOrderItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            ReplaceStateUserForOrderItemsAsync([FromBody] Application.OrderInfoFeature.Commands.ReplaceStateUserForOrderItemsCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        string reason = "اتمام موجودی و درخواست تغییر کالا";
                        int status = 3;
                        var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemTbl", command.OrderId, status, reason);
                        var tasklogOrder = SendDataForOrderLog(createDate, reason, command.OrderId, 0, 0);

                        Task.WaitAll(tasklog, tasklogOrder);

                    }
                    catch
                    {

                    }

                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        #region ChangeStateUserForOrderItems

        [HttpPost("ChangeStateUserForOrderItems")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            ChangeStateUserForOrderItemsAsync([FromBody] Application.OrderInfoFeature.Commands.ChangeStateUserForOrderItemsCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        string reason = "درخواست تغییر وضعیت";
                        int status = command.State;
                        var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemTbl", command.OrderId, status, reason);
                        var tasklogOrder = SendDataForOrderLog(createDate, reason, command.OrderId, 0, 0);

                        Task.WaitAll(tasklog, tasklogOrder);

                    }
                    catch
                    {

                    }

                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        //----------------------------------
        //----------------------------------

        #region CreateItemReserve

        [HttpPost("CreateItemReserve")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<long>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<long>>>
            CreateItemReserveAsync([FromBody] Application.OrderInfoFeature.Commands.CreateOrderItemsReserveCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<long> result =
                new FluentResults.Result<long>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    //try
                    //{
                    //    string action = ControllerContext.ActionDescriptor.ActionName;
                    //    var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemsReserveTbl", command.OrderItemId, command.OrderInfo.OrderState, "ثبت سفارش");
                    //    //tasklog.Start();

                    //    string storeId = Math.Round(command.OrderInfo.StoreId, 3).ToString(System.Globalization.CultureInfo.InvariantCulture);
                    //    var tasklogOrder = SendDataForOrderLog(createDate, "ثبت سفارش توسط کاربر کال سنتر در شعبه" + storeId, command.OrderInfo.Id, command.OrderInfo.OrderCode, command.OrderInfo.Detail.UserId);

                    //    tasklogOrder.Start();

                    //    Task.WaitAll(tasklog, tasklogOrder);
                    //}
                    //catch
                    //{

                    //}

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

        #region UpdateItemReserve

        [HttpPost("UpdateItemReserve")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            UpdateItemReserveAsync([FromBody] Application.OrderInfoFeature.Commands.UpdateOrderItemsReserveCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    //try
                    //{
                    //    string action = ControllerContext.ActionDescriptor.ActionName;
                    //    var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemsReserveTbl", command.OrderItemId, command.OrderInfo.OrderState, "ثبت سفارش");
                    //    //tasklog.Start();

                    //    string storeId = Math.Round(command.OrderInfo.StoreId, 3).ToString(System.Globalization.CultureInfo.InvariantCulture);
                    //    var tasklogOrder = SendDataForOrderLog(createDate, "ثبت سفارش توسط کاربر کال سنتر در شعبه" + storeId, command.OrderInfo.Id, command.OrderInfo.OrderCode, command.OrderInfo.Detail.UserId);

                    //    tasklogOrder.Start();

                    //    Task.WaitAll(tasklog, tasklogOrder);
                    //}
                    //catch
                    //{

                    //}

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

        #region DeleteItemReserve

        [HttpPost("DeleteItemReserve")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<bool>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<bool>>>
            DeleteItemReserveAsync([FromBody] Application.OrderInfoFeature.Commands.DeleteOrderItemsReserveCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    //try
                    //{
                    //    string action = ControllerContext.ActionDescriptor.ActionName;
                    //    var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemsReserveTbl", command.OrderItemId, command.OrderInfo.OrderState, "ثبت سفارش");
                    //    //tasklog.Start();

                    //    string storeId = Math.Round(command.OrderInfo.StoreId, 3).ToString(System.Globalization.CultureInfo.InvariantCulture);
                    //    var tasklogOrder = SendDataForOrderLog(createDate, "ثبت سفارش توسط کاربر کال سنتر در شعبه" + storeId, command.OrderInfo.Id, command.OrderInfo.OrderCode, command.OrderInfo.Detail.UserId);

                    //    tasklogOrder.Start();

                    //    Task.WaitAll(tasklog, tasklogOrder);
                    //}
                    //catch
                    //{

                    //}

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

        #region GetOrderItemsReserve

        [HttpPost("GetOrderItemsReserve")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.OrderItemsReserve>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.OrderItemsReserve>>>>
            GetOrderItemsReserveAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderItemsReserveDetailsCommand command)
        {
            FluentResults.Result<List<Domain.Entities.OrderItemsReserve>> result =
                new FluentResults.Result<List<Domain.Entities.OrderItemsReserve>>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);

                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        //-------------------------------------
        //-------------------------------------

        #region GetOrderByStatusItem

        [HttpPost("GetOrderByStatusItem")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.OrderByStatusItem>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.OrderByStatusItem>>>>
            GetOrderByStatusItemAsync([FromBody] Application.OrderInfoFeature.Commands.GetOrderByStatusItem command)
        {
            FluentResults.Result<List<Domain.Entities.OrderByStatusItem>> result =
                new FluentResults.Result<List<Domain.Entities.OrderByStatusItem>>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);

                return BadRequest(error: result.ToResult());
            }


        }

        #endregion

        #region ReplaceProductToOrderAccept

        [HttpPost("ReplaceProductToOrderAccept")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result>>
            ReplaceProductToOrderAcceptAsync([FromBody] Application.OrderInfoFeature.Commands.ReplaceProductToOrderCommand command)
        {
            DateTime createDate = System.DateTime.Now;

            FluentResults.Result result =
                new FluentResults.Result();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    try
                    {
                        string action = ControllerContext.ActionDescriptor.ActionName;
                        var tasklog = SendDataForLog(createDate, command, action, "CustomerPreOrderItemsTbl", command.OrginalItemId, 2, "جایگزینی کالا");

                        Task.WaitAll(tasklog);
                    }
                    catch
                    {

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

        //-------------------------------
        //-------------------------------

        #region GetCustomerOrder

        [HttpPost("GetCustomerOrder")]
        [ProducesResponseType
        (type: typeof(FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType
        (type: typeof(FluentResults.Result),
            statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async
            Task<ActionResult<FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>>>
            GetCustomerOrderAsync([FromBody] Application.OrderInfoFeature.Commands.GetCustomerOrder command)
        {
            FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>> result =
                new FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>();
            try
            {

                result = await Mediator.Send(command);

                if (result.IsSuccess)
                {
                    return Ok(value: result);
                }
                else
                {
                    return BadRequest(error: result.ToResult());
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);

                return BadRequest(error: result.ToResult());
            }


        }

        #endregion
    }
}
