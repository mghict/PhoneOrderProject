using AccessManagment.Application.User.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.User.CommandsHandler
{
    public class GetAllUserByAppIdAndStoreIdAndSearchCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllUserByAppIdAndStoreIdAndSearchCommand, FluentResults.Result<Domain.Entities.UserModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllUserByAppIdAndStoreIdAndSearchCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.UserModel>> Handle(GetAllUserByAppIdAndStoreIdAndSearchCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.UserModel> result = new Result<Domain.Entities.UserModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetAllUserByAppIdAndStoreIdAndSearchCommand, Domain.Entities.UserModel>
                        (validator: new Validators.GetAllUserByAppIdAndStoreIdAndSearchValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var model = await UnitOfWork.UserQueryRepository.GetAllByAppIdAndStoreIdAndSearchAsync(request.ApplicationId, request.StoreId, request.SearchKey, request.PageNumber, request.PageSize);

                if (model != null)
                {
                    result.WithValue(model);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new Domain.Entities.UserModel());
            }

            return result;
        }
    }
}
