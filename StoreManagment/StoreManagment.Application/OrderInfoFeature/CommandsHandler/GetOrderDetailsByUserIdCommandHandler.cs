using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetOrderDetailsByUserIdCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetOrderDetailsByUserIdCommand, FluentResults.Result<List<Domain.Entities.GetOrderDetailsByUserId>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetOrderDetailsByUserIdCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetOrderDetailsByUserId>>> Handle(GetOrderDetailsByUserIdCommand request, CancellationToken cancellationToken)
        {
            Result<List<GetOrderDetailsByUserId>> result = new Result<List<GetOrderDetailsByUserId>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetOrderDetailsByUserIdCommand, List<GetOrderDetailsByUserId>>
                            (validator: new Validators.GetOrderDetailsByUserIdValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp=await UnitOfWork.OrderInfoQueryRepository.getOrderDetailsByUserId(request.StartDate,request.EndDate,request.StoreId??0.0f,request.UserId??0);
                if(resp!=null && resp.Count>0)
                {
                    result.WithValue(resp);
                }
                result.WithSuccess("اطلاعات واکشی شد");
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
