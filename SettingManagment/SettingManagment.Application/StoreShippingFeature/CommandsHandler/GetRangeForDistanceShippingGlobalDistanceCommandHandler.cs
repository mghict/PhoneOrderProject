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
    public class GetRangeForDistanceShippingGlobalDistanceCommandHandler :
        MediatR.IRequestHandler<Commands.GetRangeForDistanceShippingGlobalDistanceCommand, FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetRangeForDistanceShippingGlobalDistanceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>> Handle(GetRangeForDistanceShippingGlobalDistanceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetRangeForDistanceShippingGlobalDistanceCommand, List<Domain.Entities.StoreGeneralShippingByDistanceTbl>>
                        (validator: new Validation.GetRangeForDistanceShippingGlobalDistanceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalDistanceQueryRepository.GetByRange(request.Distance);


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
