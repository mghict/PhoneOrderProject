using AutoMapper;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class CreateOrderItemsReserveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateOrderItemsReserveCommand, FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public CreateOrderItemsReserveCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<long>> Handle(Commands.CreateOrderItemsReserveCommand request, CancellationToken cancellationToken)
        {
            Result<long> result =
                new Result<long>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.CreateOrderItemsReserveCommand, long>
                            (validator: new Validators.CreateItemsReserveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var entity = Mapper.Map<Domain.Entities.OrderItemsReserve>(request);
                var resp = await UnitOfWork.OrderItemsReserveRepository.InsertAsync(entity);
                
                if (resp != null )
                {
                    result.WithValue(resp.Id);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }
                else
                {
                    result.WithValue(0);
                    result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
                }

                
            }
            catch (Exception ex)
            {
                result.WithValue(0);
                result.WithError(ex.Message);
                result.WithError(BehsamFramework.Resources.Messages.ErrorDone);
            }

            return result;
        }
    }
}
