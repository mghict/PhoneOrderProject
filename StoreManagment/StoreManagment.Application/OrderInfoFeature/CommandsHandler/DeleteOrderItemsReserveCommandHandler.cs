using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class DeleteOrderItemsReserveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeleteOrderItemsReserveCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public DeleteOrderItemsReserveCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(Commands.DeleteOrderItemsReserveCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result =
                new Result<bool>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.DeleteOrderItemsReserveCommand, bool>
                            (validator: new Validators.DeleteOrderItemsReserveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var resp = await UnitOfWork.OrderItemsReserveRepository.DeleteByIdAsync(request.Id);

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
