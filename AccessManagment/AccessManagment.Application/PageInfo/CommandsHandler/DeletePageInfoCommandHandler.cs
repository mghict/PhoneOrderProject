using AccessManagment.Application.PageInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.CommandsHandler
{
    public class DeletePageInfoCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeletePageInfoCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public DeletePageInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<bool>> Handle(DeletePageInfoCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeletePageInfoCommand, bool>
                        (validator: new Validators.DeletePageInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = await QueryUnitOfWork.PageInfoQueryRepository.GetByIdAsync(request.Id);
                if(entity==null)
                {
                    return result.WithError(BehsamFramework.Resources.Messages.DataNotFound).WithValue(false);
                }
                var lst = await UnitOfWork.PageInfoRepository.DeleteAsync(entity);
                if(!lst)
                {
                    return result.WithError("دارای فرزندهای وابسته می باشد").WithValue(false);
                }

                var isTrue = await UnitOfWork.PageInfoRepository.DeleteAsync(entity);

                if (!isTrue)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(isTrue);
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
