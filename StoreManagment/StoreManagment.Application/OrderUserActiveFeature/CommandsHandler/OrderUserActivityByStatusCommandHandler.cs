using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderUserActiveFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.CommandsHandler
{
    public class OrderUserActivityByStatusCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.OrderUserActivityByStatusCommand, 
            FluentResults.Result<List<Domain.Entities.OrderUserActivityByStatus>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public OrderUserActivityByStatusCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.OrderUserActivityByStatus>>> Handle(OrderUserActivityByStatusCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.OrderUserActivityByStatus>> result =
                new Result<List<Domain.Entities.OrderUserActivityByStatus>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.OrderUserActivityByStatusCommand, List<Domain.Entities.OrderUserActivityByStatus>>
                            (validator: new Validators.OrderUserActivityByStatusValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivityByStatus(request.UserId, request.Status);
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
