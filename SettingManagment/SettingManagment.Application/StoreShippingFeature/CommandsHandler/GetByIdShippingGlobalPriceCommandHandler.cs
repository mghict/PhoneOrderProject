using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetByIdShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdShippingGlobalPriceCommand, FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdShippingGlobalPriceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.StoreGeneralShippingByPriceTbl>> Handle(GetByIdShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result< Domain.Entities.StoreGeneralShippingByPriceTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingByPriceTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdShippingGlobalPriceCommand, Domain.Entities.StoreGeneralShippingByPriceTbl>
                        (validator: new Validation.GetByIdShippingGlobalPriceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalPriceQueryRepository.GetByIdAsync(request.Id);


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
