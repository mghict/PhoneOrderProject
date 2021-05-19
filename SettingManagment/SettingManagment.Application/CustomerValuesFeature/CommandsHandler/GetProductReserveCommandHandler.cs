using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetProductReserveCommandHandler :
        MediatR.IRequestHandler<Commands.GetProductReserveCommand, FluentResults.Result<BehsamFramework.Models.ProductReserveModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetProductReserveCommandHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<BehsamFramework.Models.ProductReserveModel>> Handle(GetProductReserveCommand request, CancellationToken cancellationToken)
        {
            Result<BehsamFramework.Models.ProductReserveModel> result =
                new Result<BehsamFramework.Models.ProductReserveModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetProductReserveCommand, BehsamFramework.Models.ProductReserveModel>
                        (validator: new Validators.GetProductReserveValidator(), command: request);

                if (result.IsSuccess)
                {
                    var entity = await UnitOfWork.ProductQueryRepository.GetProductReserve(request.ItemId, request.StoreId,request.CategoryEqual,request.BrandEqual,request.BrandSearch,request.NameEqual,request.NameSearch,request.PageNumber,request.PageSize);
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
                result.WithValue(new BehsamFramework.Models.ProductReserveModel());
            }

            return result;
        }
    }
}
