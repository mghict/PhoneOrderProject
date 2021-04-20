using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class UpdateStoreShippingCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateStoreShippingCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateStoreShippingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateStoreShippingCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateStoreShippingCommand, bool>
                        (validator: new Validation.UpdateStoreShoppingValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingRepository.UpdateAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive)
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
