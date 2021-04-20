using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetByIdStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdStoreShippingAreaCommand, FluentResults.Result<Domain.Entities.StoreShippingAreaTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdStoreShippingAreaCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.StoreShippingAreaTbl>> Handle(GetByIdStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.StoreShippingAreaTbl> result =
                new FluentResults.Result<Domain.Entities.StoreShippingAreaTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdStoreShippingAreaCommand, Domain.Entities.StoreShippingAreaTbl>
                        (validator: new Validation.GetByIdStoreShippingAreaValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaQueryRepository.GetByIdAsync(request.Id);


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
