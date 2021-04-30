using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderUserActiveFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.CommandsHandler
{
    public class GetbyUserIdUserCurrentSummeryCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetbyUserIdUserCurrentSummeryCommand, FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public GetbyUserIdUserCurrentSummeryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>> Handle(GetbyUserIdUserCurrentSummeryCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> result =
                new Result<List<Domain.Entities.CustomerPreOrderUserActiveSummery>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetbyUserIdUserCurrentSummeryCommand, List<Domain.Entities.CustomerPreOrderUserActiveSummery>>
                            (validator: new Validators.GetbyUserIdUserCurrentSummeryValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivitySummeryinCurrentDate(request.UserId);
                if (resp != null && resp.Count > 0)
                {
                    result.WithSuccess("اطلاعات یافت شد");
                }
                else
                {
                    result.WithError("اطلاعات یافت نشد");
                }

                result.WithValue(resp);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
