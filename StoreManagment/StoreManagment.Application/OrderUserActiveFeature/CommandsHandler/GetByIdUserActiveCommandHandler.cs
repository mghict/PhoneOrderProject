using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderUserActiveFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.CommandsHandler
{
    public class GetByIdUserActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdUserActiveCommand, FluentResults.Result<Domain.Entities.CustomerPreOrderUserActive>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public GetByIdUserActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<Domain.Entities.CustomerPreOrderUserActive>> Handle(GetByIdUserActiveCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.CustomerPreOrderUserActive> result = 
                new Result<Domain.Entities.CustomerPreOrderUserActive>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetByIdUserActiveCommand, Domain.Entities.CustomerPreOrderUserActive>
                            (validator: new Validators.GetByIdUserActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await QueryUnitOfWork.UserActiveQueryRepository.GetByIdAsync(request.Id);
                if (resp!=null)
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
