using AccessManagment.Application.UserRole.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserRole.CommandsHandler
{
    public class GetUserRoleByUserHandler :
        MediatR.IRequestHandler<Commands.GetUserRoleByUserCommand, FluentResults.Result<List<Domain.Entities.UserRoleAccessTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetUserRoleByUserHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.UserRoleAccessTbl>>> Handle(GetUserRoleByUserCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.UserRoleAccessTbl>> result = new Result<List<Domain.Entities.UserRoleAccessTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetUserRoleByUserCommand, List<Domain.Entities.UserRoleAccessTbl>>
                        (validator: new Validations.GetUserRoleByUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var resp = await UnitOfWork.UserRoleQueryRepository.GetAllByUserId(request.UserId);

                if (resp == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(resp);
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
