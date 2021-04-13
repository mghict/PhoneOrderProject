using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class DeleteUserCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteUserCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();
            result.WithValue(false);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteUserCommand, bool>
                        (validator: new Validators.DeleteUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var existsItem = await QueryUnitOfWork.UserQueryRepository.GetByIdAsync(request.Id);
                if (existsItem == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                var resp = await UnitOfWork.UserRepository.DeleteByIdAsync(request.Id);

                if (resp)
                {
                    result.WithValue(resp);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }
                else
                {
                    result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
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
