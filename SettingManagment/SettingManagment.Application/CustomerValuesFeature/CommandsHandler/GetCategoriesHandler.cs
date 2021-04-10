using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetCategoriesHandler :
        MediatR.IRequestHandler<Commands.GetCategoriesCommand, FluentResults.Result<BehsamFramework.Models.CategoriesModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetCategoriesHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<BehsamFramework.Models.CategoriesModel>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            Result<BehsamFramework.Models.CategoriesModel> result =
                new Result<BehsamFramework.Models.CategoriesModel>();

            try
            {
                

                if (result.IsSuccess)
                {
                    var entity = await UnitOfWork.CategoryQueryRepository.GetCategoryAllAsync(request.CategoryName, request.PageNumber, request.PageSize);
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
                result.WithValue(new BehsamFramework.Models.CategoriesModel
                {
                    RowCount = 0,
                    Categories = new List<BehsamFramework.Models.CategoryShowModel>()
                });
            }

            return result;
        }
    }
}
