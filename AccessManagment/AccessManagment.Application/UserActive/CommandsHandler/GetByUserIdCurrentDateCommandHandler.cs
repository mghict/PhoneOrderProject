using System;
using System.Threading.Tasks;
using AutoMapper;
using AccessManagment.Persistence;
using AccessManagment.Application.UserActive.Commands;
using FluentResults;
using System.Threading;

namespace AccessManagment.Application.UserActive.CommandsHandler
{
    public class GetByUserIdCurrentDateCommandHandler :
        MediatR.IRequestHandler<Commands.GetByUserIdCurrentDateCommands, FluentResults.Result<Domain.Entities.UserActiveInfo>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetByUserIdCurrentDateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<Domain.Entities.UserActiveInfo>> Handle(GetByUserIdCurrentDateCommands request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.UserActiveInfo> result = new Result<Domain.Entities.UserActiveInfo>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByUserIdCurrentDateCommands, Domain.Entities.UserActiveInfo>
                        (validator: new Validators.GetByUserIdCurrentDateValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var respUpdate = await QueryUnitOfWork.UserActiveQueryRepository.GetByUserIdCurrentDateAsync(request.UserId);

                result.WithValue(respUpdate);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);


            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
