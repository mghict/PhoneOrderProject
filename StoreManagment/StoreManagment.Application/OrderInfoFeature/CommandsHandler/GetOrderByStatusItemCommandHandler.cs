using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetOrderByStatusItemCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetOrderByStatusItem, FluentResults.Result<List<Domain.Entities.OrderByStatusItem>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetOrderByStatusItemCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<List<Domain.Entities.OrderByStatusItem>>> Handle(GetOrderByStatusItem request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.OrderByStatusItem>> result = new Result<List<Domain.Entities.OrderByStatusItem>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetOrderByStatusItem, List<Domain.Entities.OrderByStatusItem>>
                            (validator: new Validators.GetOrderByStatusItemValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderInfoQueryRepository.getOrderByStatusItem(request.Status,request.ItemStatus,request.UserId);
                if (resp != null)
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
