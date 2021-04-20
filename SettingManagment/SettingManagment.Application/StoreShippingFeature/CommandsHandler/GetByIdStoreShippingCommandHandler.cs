using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetByIdStoreShippingCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdStoreShippingCommand, FluentResults.Result<Domain.Entities.StoreShippingTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdStoreShippingCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.StoreShippingTbl>> Handle(GetByIdStoreShippingCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.StoreShippingTbl> result =
                new FluentResults.Result<Domain.Entities.StoreShippingTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdStoreShippingCommand, Domain.Entities.StoreShippingTbl>
                        (validator: new Validation.GetByIdStoreShoppingValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingQueryRepository.GetByIdAsync(request.Id);


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
