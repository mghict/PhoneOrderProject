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
    class UpdateUserCommandHandler:
        object,
        MediatR.IRequestHandler
        <Commands.UpdateUserCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {

                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateUserCommand>
                        (validator: new Validators.UpdateUserValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.UserInfoTbl>(request);
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
