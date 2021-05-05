using AutoMapper;
using BillManagement.Application.BillFeature.Commands;
using BillManagement.Domain.Entities;
using BillManagement.Persistence;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BillManagement.Application.BillFeature.CommandsHandler
{
    public class GetOrderDetailCommadHandler:
        MediatR.IRequestHandler<Commands.GetOrderDetailCommand,FluentResults.Result<Domain.Entities.OrderResponse>>
    {
        private AutoMapper.IMapper Mapper { get; }
        private Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        private Persistence.IUnitOfWork UnitOfWork { get; }

        public GetOrderDetailCommadHandler(IMapper mapper, IQueryUnitOfWork queryUnitOfWork, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            QueryUnitOfWork = queryUnitOfWork;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<OrderResponse>> Handle(GetOrderDetailCommand request, CancellationToken cancellationToken)
        {
            Result<OrderResponse> result =
                new Result<OrderResponse>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetOrderDetailCommand, OrderResponse>
                        (validator: new Validators.GetOrderDetailValidator(), command: request);

                if (result.IsFailed)
                {
                    result.WithValue(new OrderResponse());
                    return result;
                }

                var resp = await QueryUnitOfWork.OrderQueryRepository.GetInfoForBill(request.OrderCode);
                
                if(resp==null || resp.OrderCode<=0 || resp.OrderItems==null || resp.OrderItems.Count<=0)
                {
                    result.WithValue(new OrderResponse());
                    result.WithError(BehsamFramework.Resources.Messages.DataNotFound);
                    return result;
                }

                result.WithValue(resp);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch(Exception ex)
            {
                result.WithError("RunTimeError: "+ex.Message);
                result.WithValue(new OrderResponse());
            }

            return result;
        }
    }
}
