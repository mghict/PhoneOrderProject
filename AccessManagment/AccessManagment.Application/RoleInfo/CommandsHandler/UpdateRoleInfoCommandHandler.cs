using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.CommandsHandler
{
    public class UpdateRoleInfoCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateRoleInfoCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateRoleInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateRoleInfoCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateRoleInfoCommand, bool>
                        (validator: new Validators.UpdateRoleInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.RoleInfoTbl>(request);

                var isTrue = await UnitOfWork.RoleInfoRepository.UpdateAsync(entity);

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
