using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuthoManagment.Application.LoginFeature.Command;
using AuthoManagment.Application.Security;
using AuthoManagment.Persistence;
using AutoMapper;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using crypto;
using FluentResults;

namespace AuthoManagment.Application.LoginFeature.CommandHandler
{
    public class LoginCommandHandler:
        object,MediatR.IRequestHandler
        <Command.LoginCommand,FluentResults.Result<BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public LoginCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Token>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Token> result = new FluentResults.Result<Token>();

            try
            {
                result =
                    await Utility.Validate<Command.LoginCommand, BehsamFramework.DTOs.OutPutDTOs.TokenDTO.Token>
                        (validator: new Validators.LoginCommandValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                Security.SecurePasswordHasherHelper sec = new SecurePasswordHasherHelper();

                // **************************************************
                var user = await UnitOfWork
                                    .UserInfoQueryRepository
                                    .Login(userName: request.UserName,
                                           sec.Hash(request.Password),
                                           applicationId:request.ApplicationId
                                        );
                if (user == null)
                {
                    throw new Exception(Resources.Messages.UserNamePassNotFound);
                }

                
                /*if (!sec.Verify(request.Password, user.Password))
                {
                    throw new Exception(Resources.Messages.UserNamePassNotFound);
                }*/

                // **************************************************

                // **************************************************
                Security.TokenSecurity tokenSecurity = new TokenSecurity();

                Token token = new Token()
                {
                    TokenValue = tokenSecurity.GenerateJWTToken(user)
                };

                result.WithValue(value: token);

                string successInsert =
                    string.Format(Resources.Messages.SuccessDone, nameof(token));

                result.WithSuccess
                    (successMessage: successInsert);
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
