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
    public class GetUserActivityOrderLogsCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetUserActivityOrderLogsCommand, FluentResults.Result<List<Domain.Entities.UserActivityLogs>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public GetUserActivityOrderLogsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.UserActivityLogs>>> Handle(GetUserActivityOrderLogsCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.UserActivityLogs>> result =
                new Result<List<Domain.Entities.UserActivityLogs>>();

            try
            {
                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivityLogs(request.FromDate,request.ToDate, request.UserId);
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
