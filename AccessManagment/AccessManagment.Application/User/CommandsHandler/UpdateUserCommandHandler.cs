using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class UpdateUserCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateUserCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();
            result.WithValue(false);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateUserCommand, bool>
                        (validator: new Validators.UpdateUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var existsItem =await QueryUnitOfWork.UserQueryRepository.GetByIdAsync(request.Id);
                if(existsItem==null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                var entity = new Domain.Entities.UserInfoTbl()
                {
                    Id = existsItem.Id,
                    Password = existsItem.Password,
                    UserName = existsItem.UserName,
                    //-------------------------------
                    Status = request.Status,
                    Storeid = request.Storeid,
                    Name = request.Name
                };

                var resp = await UnitOfWork.UserRepository.UpdateAsync(entity);

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
