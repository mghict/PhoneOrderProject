using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    //GetOrderInfoWithItemsCommand

    public class GetOrderInfoWithItemsCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetOrderInfoWithItemsCommand, FluentResults.Result<Domain.Entities.GetOrderInfoWithItems>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetOrderInfoWithItemsCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<Domain.Entities.GetOrderInfoWithItems>> Handle(GetOrderInfoWithItemsCommand request, CancellationToken cancellationToken)
        {
            Result<GetOrderInfoWithItems> result = new Result<GetOrderInfoWithItems>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetOrderInfoWithItemsCommand, GetOrderInfoWithItems>
                            (validator: new Validators.GetOrderInfoWithItemsValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderInfoQueryRepository.getOrderInfoWithItems(request.OrderCode);
                if (resp != null)
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
