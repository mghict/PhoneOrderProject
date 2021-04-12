using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.CommandsHandler
{
    public class GetRoleInfoByApplicationCommandHandler :
        MediatR.IRequestHandler<Commands.GetRoleInfoByApplicationCommand, FluentResults.Result<List<Domain.Entities.RoleInfoTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetRoleInfoByApplicationCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.RoleInfoTbl>>> Handle(GetRoleInfoByApplicationCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.RoleInfoTbl>> result = new Result<List<Domain.Entities.RoleInfoTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetRoleInfoByApplicationCommand, List<Domain.Entities.RoleInfoTbl>>
                        (validator: new Validators.GetRoleInfoByApplicationValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var lst = await UnitOfWork.RoleInfoQueryRepository.GetByApplication(request.ApplicationId);

                if (lst==null ||lst.Count==0)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

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
