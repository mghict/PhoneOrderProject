using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetSummeryOrderStatusByDateCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetSummeryOrderStatusByDate, FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetSummeryOrderStatusByDateCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>> Handle(GetSummeryOrderStatusByDate request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.GetSummeryOrderStatusByDate>> result = new Result<List<Domain.Entities.GetSummeryOrderStatusByDate>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetSummeryOrderStatusByDate, List<Domain.Entities.GetSummeryOrderStatusByDate>>
                            (validator: new Validators.GetSummeryOrderStatusByDateValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var lst = await UnitOfWork.OrderInfoQueryRepository.getSummeryOrderStatusByDate(request.StoreId, request.StartDate, request.EndDate);
                if (lst != null && lst.Count > 0)
                {
                    result.WithValue(lst);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
