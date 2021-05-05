using AutoMapper;
using BillManagement.Application.BillFeature.Commands;
using BillManagement.Persistence;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BillManagement.Application.BillFeature.CommandsHandler
{
    public class LoginUserCommadHandler :
        MediatR.IRequestHandler<Commands.LoginUserCommand, FluentResults.Result<string>>
    {
        private AutoMapper.IMapper Mapper { get; }
        private Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        private Persistence.IUnitOfWork UnitOfWork { get; }
        private Token.ITokenCreate Token { get; }


        public LoginUserCommadHandler(IMapper mapper, IQueryUnitOfWork queryUnitOfWork, IUnitOfWork unitOfWork, Token.ITokenCreate token)
        {
            Mapper = mapper;
            QueryUnitOfWork = queryUnitOfWork;
            UnitOfWork = unitOfWork;
            Token = token;
        }

        public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            Result<string> result =
                new Result<string>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.LoginUserCommand, string>
                        (validator: new Validators.LoginUserValidator(), command: request);

                if (result.IsFailed)
                {
                    result.WithValue(string.Empty);
                    return result;
                }

                result = await Token.GenerateJWTToken(request.UserName, request.Password);

            }
            catch (Exception ex)
            {
                result.WithError("RunTimeError: " + ex.Message);
                result.WithValue(string.Empty);
            }

            return result;
        }
    }
}
