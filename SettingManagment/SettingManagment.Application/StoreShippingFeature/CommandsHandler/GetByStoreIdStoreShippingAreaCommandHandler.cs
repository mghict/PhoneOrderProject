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
    public class GetByStoreIdStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.GetByStoreIdStoreShippingAreaCommand, FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByStoreIdStoreShippingAreaCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreShippingAreaTbl>>> Handle(GetByStoreIdStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByStoreIdStoreShippingAreaCommand, List<Domain.Entities.StoreShippingAreaTbl>>
                        (validator: new Validation.GetByStoreIdStoreShippingAreaValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaQueryRepository.GetByStoreId(request.StoreId);


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
            finally
            {

            }
            return result;
        }
    }
}
