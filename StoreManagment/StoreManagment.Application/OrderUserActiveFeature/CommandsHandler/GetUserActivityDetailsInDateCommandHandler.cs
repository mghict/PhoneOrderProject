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
    public class GetUserActivityDetailsInDateCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetUserActivityDetailsInDateCommand, FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public GetUserActivityDetailsInDateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.CustomerPreOrderUserActive>>> Handle(GetUserActivityDetailsInDateCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.CustomerPreOrderUserActive>> result =
                new Result<List<Domain.Entities.CustomerPreOrderUserActive>>();

            try
            {
                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivityDetailsInDate(request.OrderDate,request.StoreId, request.UserId);
                if (resp != null && resp.Count>0)
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
