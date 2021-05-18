using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetOrderItemsReserveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetOrderItemsReserveDetailsCommand, FluentResults.Result<List<Domain.Entities.OrderItemsReserve>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetOrderItemsReserveCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.OrderItemsReserve>>> Handle(Commands.GetOrderItemsReserveDetailsCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.OrderItemsReserve>> result =
                new Result<List<Domain.Entities.OrderItemsReserve>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetOrderItemsReserveDetailsCommand, List<Domain.Entities.OrderItemsReserve>>
                            (validator: new Validators.GetOrderItemsReserveDetailsValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderItemsReserveRepository.GetOrderItemsReserveDetailsAsync(request.ItemId);
                if (resp != null && resp.Count > 0)
                {
                    result.WithValue(resp);
                }

                result.WithSuccess("اطلاعات واکشی شد");
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
