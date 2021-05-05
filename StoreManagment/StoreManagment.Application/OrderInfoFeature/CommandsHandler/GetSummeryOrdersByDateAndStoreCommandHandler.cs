using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetSummeryOrdersByDateAndStoreCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetSummeryOrdersByDateAndStore, FluentResults.Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetSummeryOrdersByDateAndStoreCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>> Handle(Commands.GetSummeryOrdersByDateAndStore request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>> result = 
                new Result<List<Domain.Entities.GetSummeryOrdersByDateAndStore>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetSummeryOrdersByDateAndStore, List<Domain.Entities.GetSummeryOrdersByDateAndStore>>
                            (validator: new Validators.GetSummeryOrdersByDateAndStoreValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderInfoQueryRepository.getSummeryOrdersByDateAndStore(request.OrderDate, request.StoreId);
                if (resp != null && resp.Count > 0)
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
