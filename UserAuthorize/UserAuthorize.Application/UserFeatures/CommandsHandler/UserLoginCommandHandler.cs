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
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UserLoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public Task<Result<LoginModel>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
