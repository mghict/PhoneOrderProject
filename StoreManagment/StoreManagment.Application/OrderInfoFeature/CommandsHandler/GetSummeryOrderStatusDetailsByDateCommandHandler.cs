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
    public class GetSummeryOrderStatusDetailsByDateCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetSummeryOrderStatusDetailsByDate, FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetSummeryOrderStatusDetailsByDateCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>> Handle(GetSummeryOrderStatusDetailsByDate request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>> result = 
                new Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetSummeryOrderStatusDetailsByDate, List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>
                            (validator: new Validators.GetSummeryOrderStatusDetailsByDateValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var lst = await UnitOfWork.OrderInfoQueryRepository.getSummeryOrderStatusDetailsByDate(request.StoreId, request.StartDate, request.EndDate,request.Status);
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
