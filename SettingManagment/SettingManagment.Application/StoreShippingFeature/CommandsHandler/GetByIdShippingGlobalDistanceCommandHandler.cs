using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetByIdShippingGlobalDistanceCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdShippingGlobalDistanceCommand, FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdShippingGlobalDistanceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.StoreGeneralShippingByDistanceTbl>> Handle(GetByIdShippingGlobalDistanceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingByDistanceTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdShippingGlobalDistanceCommand, Domain.Entities.StoreGeneralShippingByDistanceTbl>
                        (validator: new Validation.GetByIdShippingGlobalDistanceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalDistanceQueryRepository.GetByIdAsync(request.Id);


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
