using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class CreateUserCommandHandler :
        MediatR.IRequestHandler<Commands.CreateUserCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Result<int> result = new Result<int>();
            result.WithValue(0);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateUserCommand, int>
                        (validator: new Validators.CreateUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.UserInfoTbl>(request);
                entity.Password = Hashing.CreateMD5(request.Password);
                
                var resp=await UnitOfWork.UserRepository.InsertAsync(entity);

                if(resp!=null)
                {
                    result.WithValue(resp.Id);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(0);
            }

            return result;
        }
    }
}
