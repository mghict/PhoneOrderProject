using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetShippingGlobalCommandHandler :
        MediatR.IRequestHandler<Commands.GetShippingGlobalCommand, FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetShippingGlobalCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.StoreGeneralShippingTbl>> Handle(GetShippingGlobalCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl> result =
                new FluentResults.Result<Domain.Entities.StoreGeneralShippingTbl>();

            try
            {

                // **************************************************


                var res = await UnitOfWork.ShippingGlobalQueryRepository.GetByIdAsync(1);


                // **************************************************

                // **************************************************

                if (res != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(res);

                }
                else
                {
                    result.WithValue(new Domain.Entities.StoreGeneralShippingTbl() { Id=1,ShippingPrice=0});
                }
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
                result.WithValue(new Domain.Entities.StoreGeneralShippingTbl() { Id = 1, ShippingPrice = 0 });
            }

            return result;
        }
    }
}
