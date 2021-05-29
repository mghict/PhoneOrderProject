using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class CreateOrderCommandHandler:
        Object,
        MediatR.IRequestHandler
        <Commands.CreateOrderCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public  CreateOrderCommandHandler (IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.CreateOrderCommand>
                            (validator: new Validators.CreateOrderValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                if (request.OrderInfo.Id == 0)
                {
                    await UnitOfWork.OrderInfoRepository.RegisterOrderAsync(request.OrderInfo);
                }
                else
                {
                    var exists = await QueryUnitOfWork.OrderInfoQueryRepository.GetByIdAsync(request.OrderInfo.Id);
                    if(exists!=null && exists.Id>0)
                    {
                        await UnitOfWork.OrderInfoRepository.UpdateOrderAsync(request.OrderInfo);
                    }
                    else
                    {
                        await UnitOfWork.OrderInfoRepository.RegisterOrderAsync(request.OrderInfo);
                    }
                }
                result.WithSuccess("اطلاعات ذخیره شد");
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
