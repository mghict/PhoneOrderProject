using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class GetAllUserCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllUserCommand, FluentResults.Result<List<Domain.Entities.UserInfoTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetAllUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<Domain.Entities.UserInfoTbl>>> Handle(Commands.GetAllUserCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.UserInfoTbl>> result =
                new Result<List<Domain.Entities.UserInfoTbl>>();

            result.WithValue(new List<Domain.Entities.UserInfoTbl>());

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetAllUserCommand, List<Domain.Entities.UserInfoTbl>>
                        (validator: new Validators.GetAllUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var existsItem = await QueryUnitOfWork.UserQueryRepository.GetAllAsync();
                if (existsItem == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }
                else
                {
                    result.WithValue(existsItem.ToList());
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new List<Domain.Entities.UserInfoTbl>());
            }

            return result;
        }
    }
}
