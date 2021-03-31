using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.Util.Security;
using FluentResults;
using UserManagment.Application.UsersFeature.Commands;
using UserManagment.Persistence;

namespace UserManagment.Application.UsersFeature.CommandsHandler
{
    class ResetUserPasswordCommandHandler :
        object,
        MediatR.IRequestHandler
        <Commands.ResetUserPasswordCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public ResetUserPasswordCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {

                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.ResetUserPasswordCommand>
                        (validator: new Validators.ResetUserPasswordValidator(), command: request);

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
                if (entity.Password != obj.Password)
                {
                    throw new Exception("Current PassWord is worng");
                }

                BehsamFramework.Util.Security.SecurePasswordHasherHelper helper =
                    new SecurePasswordHasherHelper();
                
                entity.Id = obj.Id;
                entity.Password = helper.Hash(request.NewPassword);

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
