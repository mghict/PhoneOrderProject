using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetRangeShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.GetRangeShippingGlobalPriceCommand, FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetRangeShippingGlobalPriceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>> Handle(GetRangeShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetRangeShippingGlobalPriceCommand, List<Domain.Entities.StoreGeneralShippingByPriceTbl>>
                        (validator: new Validation.GetRangeShippingGlobalPriceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalPriceQueryRepository.GetByRange(request.FromAmount,request.ToAmount);


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(inActive);
                }
                else
                {
                    result.WithError
                        (BehsamFramework.Resources.Messages.ErrorDone);
                }
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }

            return result;
        }
    }
}
