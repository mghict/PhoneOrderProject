using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class UpdateShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateShippingGlobalPriceCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateShippingGlobalPriceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result =
                new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateShippingGlobalPriceCommand>
                        (validator: new Validation.UpdateShippingGlobalPriceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.StoreGeneralShippingByPriceTbl>(request);

                var inActive = await UnitOfWork.ShippingGlobalPriceRepository.UpdateAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

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
