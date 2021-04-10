using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetProductAllByStoreHandler :
        MediatR.IRequestHandler<Commands.GetProductsAllByStoreCommand, FluentResults.Result<BehsamFramework.Models.ProductsModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetProductAllByStoreHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<BehsamFramework.Models.ProductsModel>> Handle(GetProductsAllByStoreCommand request, CancellationToken cancellationToken)
        {
            Result<BehsamFramework.Models.ProductsModel> result =
                new Result<BehsamFramework.Models.ProductsModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetProductsAllByStoreCommand, BehsamFramework.Models.ProductsModel>
                        (validator: new Validators.GetProductAllByStoreValidator(), command: request);

                if (result.IsSuccess)
                {
                    var entity = await UnitOfWork.ProductQueryRepository.GetProductAllByStore(request.StoreId, request.SearchKey, request.PageNumber, request.PageSize);
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
                result.WithValue(new BehsamFramework.Models.ProductsModel()
                {
                    RowCount = 0,
                    Products = new List<BehsamFramework.Models.ProductShowModel>()
                });
            }

            return result;
        }
    }
}
