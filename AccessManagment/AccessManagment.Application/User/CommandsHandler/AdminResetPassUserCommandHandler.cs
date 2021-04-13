using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class AdminResetPassUserCommandHandler :
        MediatR.IRequestHandler<Commands.AdminResetPassUserCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public AdminResetPassUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(AdminResetPassUserCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();
            result.WithValue(false);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.AdminResetPassUserCommand, bool>
                        (validator: new Validators.AdminResetPassUserValidator(), command: request);

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

                // **************************************************

                var Password = Hashing.CreateMD5(request.NewPass);

                await UnitOfWork.UserRepository.ResetUserPassword(request.Id,Password);

                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                result.WithValue(true);
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
