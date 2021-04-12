using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.CommandsHandler
{
    public class DeleteRoleInfoCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteRoleInfoCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteRoleInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteRoleInfoCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteRoleInfoCommand, bool>
                        (validator: new Validators.DeleteRoleInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                
                var isTrue = await UnitOfWork.RoleInfoRepository.DeleteByIdAsync(request.Id);

                if (!isTrue)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(isTrue);
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
