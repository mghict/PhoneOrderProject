using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using UserManagment.Application.UsersFeature.Commands;
using UserManagment.Persistence;

namespace UserManagment.Application.UsersFeature.CommandsHandler
{
    class ResetAdminPasswordCommandHandler :
        object,
        MediatR.IRequestHandler
        <Commands.ResetAdminPasswordCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public ResetAdminPasswordCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result> Handle(ResetAdminPasswordCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {

                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.ResetAdminPasswordCommand>
                        (validator: new Validators.ResetAminPasswordValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var obj =await QueryUnitOfWork.UserQueryRepository.GetByUserName(request.UserName);
                if (obj == null)
                {
                    throw new Exception("UserName Not Found");
                }

                var entity = Mapper.Map<Domain.Entities.UserInfoTbl>(request);
                entity.Id = obj.Id;

                var operation = await UnitOfWork.UserInfoRepository.UpdateAsync(entity);
                if (!operation)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }


                // **************************************************


                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }

            return result;
        }

        
    }
}
