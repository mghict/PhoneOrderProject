using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class GetByIdUserCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdUserCommand, FluentResults.Result<Domain.Entities.UserInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetByIdUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<Domain.Entities.UserInfoTbl>> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.UserInfoTbl> result = 
                new Result<Domain.Entities.UserInfoTbl>();

            result.WithValue(new Domain.Entities.UserInfoTbl());

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdUserCommand, Domain.Entities.UserInfoTbl>
                        (validator: new Validators.GetbyIdUserValidator(), command: request);

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
                else
                {
                    result.WithValue(existsItem);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new Domain.Entities.UserInfoTbl());
            }

            return result;
        }
    }
}
