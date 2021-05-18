using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class UpdateOrderItemsReserveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdateOrderItemsReserveCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public UpdateOrderItemsReserveCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(Commands.UpdateOrderItemsReserveCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result =
                new Result<bool>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.UpdateOrderItemsReserveCommand, bool>
                            (validator: new Validators.UpdateItemsReserveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var entity = Mapper.Map<Domain.Entities.OrderItemsReserve>(request);
                var resp = await UnitOfWork.OrderItemsReserveRepository.UpdateAsync(entity);

                if (resp)
                {
                    result.WithValue(resp);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }
                else
                {
                    result.WithValue(resp);
                    result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
                }


            }
            catch (Exception ex)
            {
                result.WithValue(false);
                result.WithError(ex.Message);
                result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
            }

            return result;
        }
    }
}
