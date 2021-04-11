using AccessManagment.Application.PageInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.CommandsHandler
{
    public class UpdatePageInfoCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdatePageInfoCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdatePageInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdatePageInfoCommand request, CancellationToken cancellationToken)
        {
            Result<int> result = new Result<int>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdatePageInfoCommand, int>
                        (validator: new Validators.UpdatePageInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.PageInfoTbl>(request);

                var isTrue = await UnitOfWork.PageInfoRepository.UpdateAsync(entity);

                if (!isTrue)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(entity.Id);
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
