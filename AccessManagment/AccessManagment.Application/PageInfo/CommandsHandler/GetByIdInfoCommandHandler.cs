using AccessManagment.Application.PageInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.CommandsHandler
{
    public class GetByIdInfoCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdPageInfoCommand, FluentResults.Result<Domain.Entities.PageInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.PageInfoTbl>> Handle(GetByIdPageInfoCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.PageInfoTbl> result = new Result<Domain.Entities.PageInfoTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdPageInfoCommand, Domain.Entities.PageInfoTbl>
                        (validator: new Validators.GetByIdPageInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = await UnitOfWork.PageInfoQueryRepository.GetByIdAsync(request.Id);

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
