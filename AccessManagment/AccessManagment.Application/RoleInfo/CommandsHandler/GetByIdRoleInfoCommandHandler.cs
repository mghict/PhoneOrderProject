using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.CommandsHandler
{
    public class GetByIdRoleInfoCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdRoleInfoCommand, FluentResults.Result<Domain.Entities.RoleInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdRoleInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.RoleInfoTbl>> Handle(GetByIdRoleInfoCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.RoleInfoTbl> result = new Result<Domain.Entities.RoleInfoTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdRoleInfoCommand, Domain.Entities.RoleInfoTbl>
                        (validator: new Validators.GetByIdRoleInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var lst = await UnitOfWork.RoleInfoQueryRepository.GetByIdAsync(request.Id);

                if (lst == null )
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
