using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class ReplaceProductToOrderCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.ReplaceProductToOrderCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public ReplaceProductToOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ReplaceProductToOrderCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.ReplaceProductToOrderCommand>
                            (validator: new Validators.ReplaceProductToOrderValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp=await UnitOfWork.OrderItemsRepository.ReplaceProductItemAsync(request.OrginalItemId,request.ReplaceProductId,request.Count);

                if(resp)
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
