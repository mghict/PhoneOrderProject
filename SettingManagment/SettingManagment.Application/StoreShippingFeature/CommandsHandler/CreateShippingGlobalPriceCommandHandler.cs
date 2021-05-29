using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class CreateShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.CreateShippingGlobalPriceCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateShippingGlobalPriceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result =
                new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateShippingGlobalPriceCommand>
                        (validator: new Validation.CreateShippingGlobalPriceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.StoreGeneralShippingByPriceTbl>(request);

                var inActive = await UnitOfWork.ShippingGlobalPriceRepository.InsertAsync(entity);


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
