using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetProductByBarcodeCommandHandler :
        MediatR.IRequestHandler<Commands.GetProductByBarCodeCommand, FluentResults.Result<Domain.Entities.ProductInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetProductByBarcodeCommandHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<Domain.Entities.ProductInfoTbl>> Handle(GetProductByBarCodeCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.ProductInfoTbl> result =
                new Result<Domain.Entities.ProductInfoTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetProductByBarCodeCommand, Domain.Entities.ProductInfoTbl>
                        (validator: new Validators.GetProductByBarcodeValidator(), command: request);

                if (result.IsSuccess)
                {
                    var entity = await UnitOfWork.ProductQueryRepository.GetProductByBarcode(request.StoreId, request.Barcode);
                    if (entity == null)
                    {
                        throw new Exception("اطلاعات یافت نشد");
                    }

                    result.WithValue(entity);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new Domain.Entities.ProductInfoTbl());
            }

            return result;
        }
    }
}
