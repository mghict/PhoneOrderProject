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
    public class OrderUserActivityByStatusItemsCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.OrderUserActivityByStatusItemsCommand,
            FluentResults.Result<List<Domain.Entities.OrderUserActivityByStatus>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public OrderUserActivityByStatusItemsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.OrderUserActivityByStatus>>> Handle(OrderUserActivityByStatusItemsCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.OrderUserActivityByStatus>> result =
                new Result<List<Domain.Entities.OrderUserActivityByStatus>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.OrderUserActivityByStatusItemsCommand, List<Domain.Entities.OrderUserActivityByStatus>>
                            (validator: new Validators.OrderUserActivityByStatusItemsValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivityByStatusItems(request.UserId, request.Status,request.ItemStatus);
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
