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
    public class GetAllShippingGlobalDistanceCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllShippingGlobalDistanceCommand, FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllShippingGlobalDistanceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>> Handle(GetAllShippingGlobalDistanceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>();

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

                var inActive = await UnitOfWork.ShippingGlobalDistanceQueryRepository.GetAllAsync();


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
