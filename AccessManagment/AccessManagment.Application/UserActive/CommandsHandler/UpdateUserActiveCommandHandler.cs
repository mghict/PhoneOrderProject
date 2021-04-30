using System;
using System.Threading.Tasks;
using AutoMapper;
using AccessManagment.Persistence;
using AccessManagment.Application.UserActive.Commands;
using FluentResults;
using System.Threading;

namespace AccessManagment.Application.UserActive.CommandsHandler
{
    public class UpdateUserActiveCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateUserActiveCommands, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateUserActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateUserActiveCommands request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateUserActiveCommands, bool>
                        (validator: new Validators.UpdateUserActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.UserActiveInfo>(request);

                var respUpdate = await UnitOfWork.UserActiveRepository.UpdateAsync(entity);
                if (respUpdate)
                {
                    result.WithValue(respUpdate);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }
                else
                {
                    result.WithValue(respUpdate);
                    result.WithSuccess(BehsamFramework.Resources.Messages.ErrorDone);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(false);
            }

            return result;
        }
    }
}
