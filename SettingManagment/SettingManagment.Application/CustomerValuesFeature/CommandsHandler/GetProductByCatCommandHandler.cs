using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetProductByCatCommandHandler :
        MediatR.IRequestHandler<Commands.GetProductByCatCommand, FluentResults.Result<List<BehsamFramework.Models.ProductShowModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetProductByCatCommandHandler(Persistence.IQueryUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<Result<List<BehsamFramework.Models.ProductShowModel>>> Handle(GetProductByCatCommand request, CancellationToken cancellationToken)
        {
            Result<List<BehsamFramework.Models.ProductShowModel>> result =
                new Result<List<BehsamFramework.Models.ProductShowModel>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetProductByCatCommand, List<BehsamFramework.Models.ProductShowModel>>
                        (validator: new Validators.GetProductByCatValidator(), command: request);

                if (result.IsSuccess)
                {
                    var entity = await UnitOfWork.ProductQueryRepository.GetProductByCatgoryAsync(request.CategoryId);
                    if (entity == null)
                    {
                        throw new Exception("اطلاعات یافت نشد");
                    }

                    var resultValue = Mapper.Map<List<BehsamFramework.Models.ProductShowModel>>(entity);

                    result.WithValue(resultValue);
                }
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(new List<BehsamFramework.Models.ProductShowModel>());
            }

            return result;
        }
    }
}
