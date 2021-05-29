using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetAllShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllShippingGlobalPriceCommand, FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllShippingGlobalPriceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>> Handle(GetAllShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByPriceTbl>>();

            try
            {
                //result =
                //    await BehsamFramework.Util.Utility.Validate<Commands.GetAllShippingGlobalPriceCommand, Domain.Entities.StoreGeneralShippingByPriceTbl>
                //        (validator: new Validation.GetShippingGlobalPriceValidator(), command: request);

                //if (result.IsFailed)
                //{
                //    return result;
                //}

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalPriceQueryRepository.GetAllAsync();


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(inActive.ToList());
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
