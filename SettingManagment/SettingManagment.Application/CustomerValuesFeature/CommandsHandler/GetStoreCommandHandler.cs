using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetStoreCommandHandler :
        MediatR.IRequestHandler<Commands.GetStoreCommand, FluentResults.Result<List<BehsamFramework.Models.StoreOrderModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetStoreCommandHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<List<BehsamFramework.Models.StoreOrderModel>>> Handle(GetStoreCommand request, CancellationToken cancellationToken)
        {
            Result<List<BehsamFramework.Models.StoreOrderModel>> result = new Result<List<BehsamFramework.Models.StoreOrderModel>>();
           
            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetStoreCommand, List<BehsamFramework.Models.StoreOrderModel>>
                        (validator: new Validators.GetStoreValidator(), command: request);

                if(result.IsSuccess)
                {
                    var entity = await UnitOfWork.StoreQueryRepository.GetStoresAsync(request.RequestDate, request.StartTime, request.EndTime, request.CustomerId);
                    if(entity==null)
                    {
                        throw new Exception("اطلاعات یافت نشد");
                    }

                    var resultValue = Mapper.Map < List<BehsamFramework.Models.StoreOrderModel>>(entity);

                    result.WithValue(resultValue);
                }
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new List<BehsamFramework.Models.StoreOrderModel>());
            }

            return result;
        }
    }
}
