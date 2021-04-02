using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserAuthorize.Application.UserFeatures.Commands;
using UserAuthorize.Persistence;

namespace UserAuthorize.Application.UserFeatures.CommandsHandler
{
    public class UserAccessCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UserAccessCommand,FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        protected Token.ITokenCreate TokenCreate { get; }
        public UserAccessCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork, Token.ITokenCreate tokenCreate)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            TokenCreate = tokenCreate;
        }

        public async Task<Result> Handle(UserAccessCommand request, CancellationToken cancellationToken)
        {
            Result result =
                new Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UserAccessCommand>
                        (validator: new Validators.UserAccessCommandValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var validationToken =await TokenCreate.ValidateUserToken(request.Token);
                if(validationToken==null || validationToken.ApplicationId<1 || validationToken.UserId<1)
                {
                    result.WithError("اطاعات ارسالی اشتباه است");
                    return result;
                }

                var response = await UnitOfWork.UserQueryRepository.UserAccessAsync(validationToken.UserId, request.MethodName, validationToken.ApplicationId);
                if (!response)
                {
                    result.WithError("اطلاعات برای دسترسی مجاز نمی باشد");
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
