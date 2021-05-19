using AutoMapper;
using BehsamFramework.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserAuthorize.Application.UserFeatures.Commands;
using UserAuthorize.Persistence;

namespace UserAuthorize.Application.UserFeatures.CommandsHandler
{
    public class UserLoginCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UserLoginCommand, FluentResults.Result<BehsamFramework.Models.LoginModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        protected Token.ITokenCreate TokenCreate { get; }
        public UserLoginCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork, Token.ITokenCreate tokenCreate)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            TokenCreate = tokenCreate;
        }

        public async Task<Result<LoginModel>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            Result<LoginModel> result =
                new Result<LoginModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UserLoginCommand, LoginModel>
                        (validator: new Validators.LoginCommandValidator(), command: request);

                if (result.IsFailed)
                {
                    result.WithValue(new LoginModel() { Token = "" });
                    return result;
                }
                var response =new  Domain.Entities.UserInfoTbl();
                try
                {
                    response = await UnitOfWork.UserQueryRepository.UserLoginAsync(request.UserName,Hashing.CreateMD5( request.Password), request.ApplicationId);

                    if (response == null)
                    {
                        result.WithError("اطلاعات برای ورود صحیح نمی باشد");
                        //result.WithValue(new LoginModel() { Token = "" });
                        return result;
                        //throw new Exception("اطلاعات برای ورود صحیح نمی باشد");
                    }
                }
                catch(Exception ex)
                {
                    result.WithError("اطلاعات برای ورود صحیح نمی باشد");
                    result.WithError(ex.Message);
                    result.WithValue(new LoginModel() { Token = string.Empty });
                    return result;
                }
            
                var model=new BehsamFramework.Models.LoginModel()
                {
                    Token = TokenCreate.GenerateJWTToken(response, request.ApplicationId)
                };

                result.WithValue(model);

            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
                result.WithError("اطلاعات برای ورود صحیح نمی باشد");
                result.WithValue(new LoginModel() { Token = string.Empty });
                return result;
            }

            return result;
        }
    }
}
