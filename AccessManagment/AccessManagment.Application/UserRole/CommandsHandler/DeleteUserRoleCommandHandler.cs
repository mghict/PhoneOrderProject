using AccessManagment.Application.UserRole.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserRole.CommandsHandler
{
    public class DeleteUserRoleCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteUserRoleCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public DeleteUserRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();
            result.WithValue(false);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteUserRoleCommand, bool>
                        (validator: new Validations.DeleteUserRoleValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = await QueryUnitOfWork.UserRoleQueryRepository.GetByIdAsync(request.Id);
                if(entity==null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }


                var resp = await UnitOfWork.UserRoleRepository.DeleteByIdAsync(request.Id);

                if (!resp)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(true);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);

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
