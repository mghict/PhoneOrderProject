using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class ChangeOrderStatusCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.ChangeOrderStatusCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public ChangeOrderStatusCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.ChangeOrderStatusCommand,bool>
                            (validator: new Validators.ChangeOrderStatusValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }


                var resp=await UnitOfWork.OrderInfoRepository.ChangeOrderStatus(request.OrderCode,request.Status,request.Reason);

                if (resp)
                {
                    result.WithSuccess("اطلاعات ذخیره شد");
                }else
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
