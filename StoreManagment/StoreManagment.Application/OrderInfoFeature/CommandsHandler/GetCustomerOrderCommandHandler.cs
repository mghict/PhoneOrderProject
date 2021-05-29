using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetCustomerOrderCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetCustomerOrder, FluentResults.Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetCustomerOrderCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>> Handle(GetCustomerOrder request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>> result =
                new Result<List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetCustomerOrder, List<Domain.Entities.GetSummeryOrderStatusDetailsByDate>>
                            (validator: new Validators.GetCustomerOrderValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var lst = await UnitOfWork.OrderInfoQueryRepository.getCustomerOrder(request.CustomerId, request.StartDate, request.EndDate);
                if (lst != null && lst.Count > 0)
                {
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                    result.WithValue(lst);
                }
                else
                {
                    result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
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
