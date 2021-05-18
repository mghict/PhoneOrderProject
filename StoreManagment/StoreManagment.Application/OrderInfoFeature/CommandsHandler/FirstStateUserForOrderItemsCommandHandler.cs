using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class FirstStateUserForOrderItemsCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.FirstStateUserForOrderItemsCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public FirstStateUserForOrderItemsCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(FirstStateUserForOrderItemsCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.FirstStateUserForOrderItemsCommand, bool>
                            (validator: new Validators.FirstStateUserForOrderItemsValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp = await UnitOfWork.OrderItemsRepository.ChangeOrderItemStatusAsync(request.ItemId, 1);

                result.WithValue(resp);

                if (resp)
                {
                    result.WithSuccess("اطلاعات ذخیره شد");
                }
                else
                {
                    result.WithError("اطلاعات ذخیره نشد");
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
