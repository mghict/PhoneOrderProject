using System;
using System.Threading.Tasks;
using AutoMapper;
using AccessManagment.Persistence;
using AccessManagment.Application.UserActive.Commands;
using FluentResults;
using System.Threading;

namespace AccessManagment.Application.UserActive.CommandsHandler
{
    public class UpdateUserActiveStatusCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateUserActiveStatusCommands, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateUserActiveStatusCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateUserActiveStatusCommands request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateUserActiveStatusCommands, bool>
                        (validator: new Validators.UpdateUserActiveStatusValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var exists = await QueryUnitOfWork.UserActiveQueryRepository.GetByUserIdCurrentDateAsync(request.UserId);
                if (exists != null && exists.Id>0)
                {
                    var respUpdate = await UnitOfWork.UserActiveRepository.UpdateStatusAsync(request.UserId, request.Status, request.CreateDate);
                    if (respUpdate)
                    {
                        result.WithValue(respUpdate);
                        result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                    }
                    else
                    {
                        result.WithValue(respUpdate);
                        result.WithSuccess(BehsamFramework.Resources.Messages.ErrorDone);
                    }
                }
                else
                {
                    var model = Mapper.Map<Domain.Entities.UserActiveInfo>(request);

                    var respInsert = await UnitOfWork.UserActiveRepository.InsertAsync(model);
                    if(respInsert.Id > 0)
                    {
                        result.WithValue(true);
                        result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                    }
                    else
                    {
                        result.WithValue(false);
                        result.WithSuccess(BehsamFramework.Resources.Messages.ErrorDone);
                    }
                }
                

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(false);
            }

            return result;
        }
    }
}
