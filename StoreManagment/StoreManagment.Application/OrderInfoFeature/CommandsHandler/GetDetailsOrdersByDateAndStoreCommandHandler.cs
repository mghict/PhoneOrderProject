using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetDetailsOrdersByDateAndStoreCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetDetailsOrdersByDateAndStore, FluentResults.Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetDetailsOrdersByDateAndStoreCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>> Handle(Commands.GetDetailsOrdersByDateAndStore request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>> result =
                new Result<List<Domain.Entities.GetDetailsOrdersByDateAndStore>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetDetailsOrdersByDateAndStore, List<Domain.Entities.GetDetailsOrdersByDateAndStore>>
                            (validator: new Validators.GetDetailsOrdersByDateAndStoreValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderInfoQueryRepository.getDetailsOrdersByDateAndStore(request.OrderDate, request.StoreId,request.OrderTime);
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
