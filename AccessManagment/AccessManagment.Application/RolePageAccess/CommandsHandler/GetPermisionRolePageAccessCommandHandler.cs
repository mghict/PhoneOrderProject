using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RolePageAccess.CommandsHandler
{
    public class GetPermisionRolePageAccessCommandHandler :
        MediatR.IRequestHandler<Commands.GetPermisionRolePageAccessCommand, FluentResults.Result<List<Domain.Entities.RolePagesAccess>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetPermisionRolePageAccessCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.RolePagesAccess>>> Handle(Commands.GetPermisionRolePageAccessCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.RolePagesAccess>> result = new Result<List<Domain.Entities.RolePagesAccess>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetPermisionRolePageAccessCommand, List<Domain.Entities.RolePagesAccess>>
                        (validator: new Validators.GetPermisionRolePageAccessValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var lst=await UnitOfWork.RolePageAccessQueryRepository.GetRolePermisions(request.RoleId);

                result.WithValue(lst);
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
