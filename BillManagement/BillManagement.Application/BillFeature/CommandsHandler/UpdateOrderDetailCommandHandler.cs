using AutoMapper;
using BillManagement.Application.BillFeature.Commands;
using BillManagement.Domain.Entities;
using BillManagement.Persistence;
using FluentResults;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillManagement.Application.BillFeature.CommandsHandler
{
    public class UpdateOrderDetailCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateOrderDetailCommand, FluentResults.Result<Domain.Entities.OrderRequest>>
    {
        private AutoMapper.IMapper Mapper { get; }
        private Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        private Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateOrderDetailCommandHandler(IMapper mapper, IQueryUnitOfWork queryUnitOfWork, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            QueryUnitOfWork = queryUnitOfWork;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<OrderRequest>> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            Result<OrderRequest> result =
                new Result<OrderRequest>();


            OrderRequest orginalRequest = new OrderRequest()
            {
                OrderCode=request.OrderCode,
                OrderItems=request.OrderItems
            };

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateOrderDetailCommand, OrderRequest>
                        (validator: new Validators.UpdateOrderDetailValidator(), command: request);

                if (result.IsFailed)
                {
                    result.WithValue(orginalRequest);
                    return result;
                }

                var resp = await QueryUnitOfWork.OrderQueryRepository.GetInfoForBill(request.OrderCode);

                if (resp == null || resp.OrderCode <= 0 || resp.OrderItems == null || resp.OrderItems.Count <= 0)
                {
                    result.WithValue(orginalRequest);
                    result.WithError(BehsamFramework.Resources.Messages.DataNotFound);
                    return result;
                }


                foreach (var item in orginalRequest.OrderItems)
                {
                    if (item.Status != 0 && item.Status != 5)
                    {
                        result.WithValue(orginalRequest);
                        result.WithError(string.Format("وضعیت کالا - بارکد {0} باید 0 و یا 5 باشد",item.ProductCode));
                        return result;
                    }

                    var existsItem = resp.OrderItems.Where(p => p.ProductId==item.ProductId).Select(s=>s.Quantity).Sum();
                    if(existsItem<=0 || existsItem!=item.Quantity)
                    {
                        result.WithValue(orginalRequest);
                        result.WithError(string.Format( "تعداد کالا ارسالی - بارکد {0} با تعداد کالای ثبت شده مغایر است",item.ProductCode));
                        return result;
                    }
                    
                }

                var respCount = resp.OrderItems.Select(s => s.Quantity).Sum();
                var requestCount = request.OrderItems.Select(s => s.Quantity).Sum();

                if(respCount!=requestCount)
                {
                    result.WithValue(orginalRequest);
                    result.WithError("تعداد کل کالای ارسالی با تعداد کل ثبت شده مغایر است");
                    return result;
                }

                var respInsert = await UnitOfWork.OrderRepository.UpdateBill(orginalRequest);

                if(respInsert)
                {
                    result.WithValue(orginalRequest);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }
                else
                {
                    result.WithValue(orginalRequest);
                    result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
                }
                
            }
            catch (Exception ex)
            {
                result.WithError("RunTimeError: " + ex.Message);
                result.WithValue(orginalRequest);
            }

            return result;
        }
    }
}
