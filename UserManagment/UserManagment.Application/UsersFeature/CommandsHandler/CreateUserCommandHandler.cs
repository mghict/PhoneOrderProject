
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using crypto;
using FluentResults;
using UserManagment.Application.UsersFeature.Commands;

namespace UserManagment.Application.UsersFeature.CommandsHandler
{
    public class CreateUserCommandHandler :
        object,
        MediatR.IRequestHandler
        <Commands.CreateUserCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public CreateUserCommandHandler(IMapper mapper, Persistence.UnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<int> result = new FluentResults.Result<int>();

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
                var entity=Mapper.Map<UserManagment.Domain.Entities.UserInfoTbl>(request);

                var user = await UnitOfWork.UserInfoRepository.InsertAsync(entity);
                if (user == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.UserNamePassNotFound);
                }

                result.WithValue(user.Id);
               // **************************************************

                // **************************************************
                

                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            finally
            {
                
            }
            return result;

        }
    }
}
