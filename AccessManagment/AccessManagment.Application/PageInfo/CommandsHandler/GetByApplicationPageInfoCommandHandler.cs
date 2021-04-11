using AccessManagment.Application.PageInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.CommandsHandler
{
    public class GetByApplicationPageInfoCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByApplicationPageInfoCommand, FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByApplicationPageInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.PageInfoTbl>>> Handle(GetByApplicationPageInfoCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.PageInfoTbl>> result = new Result<List<Domain.Entities.PageInfoTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByApplicationPageInfoCommand, List<Domain.Entities.PageInfoTbl>>
                        (validator: new Validators.GetByApplicationPageInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = await UnitOfWork.PageInfoQueryRepository.GetByApplicationId(request.ApplicationId);

                if (entity == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(entity);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
