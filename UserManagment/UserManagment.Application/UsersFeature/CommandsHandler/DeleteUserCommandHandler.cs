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
    class DeleteUserCommandHandler :
        object,
        MediatR.IRequestHandler
        <Commands.DeleteUserCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        
        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {

                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteUserCommand>
                        (validator: new Validators.DeleteUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var operation = await UnitOfWork.UserInfoRepository.DeleteByIdAsync(request.Id);
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
