using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AccessManagment.Persistence;
using AccessManagment.Application.UserActive.Commands;
using FluentResults;
using System.Threading;

namespace AccessManagment.Application.UserActive.CommandsHandler
{
    public class CreateUserActiveCommandHandler :
        MediatR.IRequestHandler<Commands.CreateUserActiveCommands, FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public CreateUserActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<long>> Handle(CreateUserActiveCommands request, CancellationToken cancellationToken)
        {
            Result<long> result = new Result<long>();
            result.WithValue(0);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateUserActiveCommands, long>
                        (validator: new Validators.CreateUserActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.UserActiveInfo>(request);

                var exists = await QueryUnitOfWork.UserActiveQueryRepository.GetByUserIdCurrentDateAsync(entity.UserId);
                if (exists == null)
                {
                    var resp = await UnitOfWork.UserActiveRepository.InsertAsync(entity);
                    if (resp != null)
                    {
                        result.WithValue(resp.Id);
                        result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                    }
                }
                else
                {
                    exists.Status = entity.Status;

                    var respUpdate = await UnitOfWork.UserActiveRepository.UpdateAsync(exists);
                    if (respUpdate)
                    {
                        result.WithValue(exists.Id);
                        result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                    }
                }



            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(0);
            }

            return result;
        }
    }
}
