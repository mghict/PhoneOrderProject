using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class GetAllUserSearchCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllUserSearchCommand, FluentResults.Result<Domain.Entities.UserModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetAllUserSearchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<Domain.Entities.UserModel>> Handle(GetAllUserSearchCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.UserModel> result =
                new Result<Domain.Entities.UserModel>();

            result.WithValue(new Domain.Entities.UserModel() { 
                RowCount=0,
                Users=new List<Domain.Entities.UserInfo>()
            });

            try
            {
                

                // **************************************************
                var items = await QueryUnitOfWork.UserQueryRepository.GetAllBySearchAsync(request.SearchKey,request.PageNumber,request.PageSize);
                if (items == null || items.Users.Count==0 || items.RowCount==0)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }
                else
                {
                    result.WithValue(items);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new Domain.Entities.UserModel()
                {
                    RowCount = 0,
                    Users = new List<Domain.Entities.UserInfo>()
                });
            }

            return result;
        }
    }
}
