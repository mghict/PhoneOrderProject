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
    public class GetbyUserIdUserCurrentDetailsCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetbyUserIdUserCurrentDetailsCommand, FluentResults.Result<List<Domain.Entities.CustomerPreOrderUserActive>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public GetbyUserIdUserCurrentDetailsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.CustomerPreOrderUserActive>>> Handle(GetbyUserIdUserCurrentDetailsCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.CustomerPreOrderUserActive>> result =
                new Result<List<Domain.Entities.CustomerPreOrderUserActive>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetbyUserIdUserCurrentDetailsCommand, List<Domain.Entities.CustomerPreOrderUserActive>>
                            (validator: new Validators.GetbyUserIdUserCurrentDetailsValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetOrderUserActivityDetailsinCurrentDate(request.UserId);
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
