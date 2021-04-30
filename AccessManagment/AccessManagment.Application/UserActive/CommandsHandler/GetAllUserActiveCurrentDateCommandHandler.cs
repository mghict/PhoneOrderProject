using System;
using System.Threading.Tasks;
using AutoMapper;
using AccessManagment.Persistence;
using AccessManagment.Application.UserActive.Commands;
using FluentResults;
using System.Threading;

namespace AccessManagment.Application.UserActive.CommandsHandler
{
    public class GetAllUserActiveCurrentDateCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllUserActiveCurrentDateCommands, FluentResults.Result<Domain.Entities.UserModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetAllUserActiveCurrentDateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<Domain.Entities.UserModel>> Handle(GetAllUserActiveCurrentDateCommands request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.UserModel> result = new Result<Domain.Entities.UserModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetAllUserActiveCurrentDateCommands, Domain.Entities.UserModel>
                        (validator: new Validators.GetAllUserActiveCurrentDateValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var respUpdate = await QueryUnitOfWork.UserActiveQueryRepository.GetUserActiveCurrentDateAsync(request.ApplicationId, request.StoreId, request.SearchKey, request.PageNumber, request.PageSize, request.Status);

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
