using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetCategoryCommandHandler :
        MediatR.IRequestHandler<Commands.GetCategoryCommand, FluentResults.Result<List<BehsamFramework.Models.CategoryShowModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetCategoryCommandHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<List<BehsamFramework.Models.CategoryShowModel>>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            Result<List<BehsamFramework.Models.CategoryShowModel>> result = 
                new Result<List<BehsamFramework.Models.CategoryShowModel>>();
           
            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetCategoryCommand, List<BehsamFramework.Models.CategoryShowModel>>
                        (validator: new Validators.GetCategoryValidator(), command: request);

                if(result.IsSuccess)
                {
                    var entity = await UnitOfWork.CategoryQueryRepository.GetCategoryByParentAsync(request.CategoryId);
                    if(entity==null)
                    {
                        throw new Exception("اطلاعات یافت نشد");
                    }

                    var resultValue = Mapper.Map < List<BehsamFramework.Models.CategoryShowModel>>(entity);

                    result.WithValue(resultValue);
                }
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new List<BehsamFramework.Models.CategoryShowModel>());
            }

            return result;
        }
    }
}
