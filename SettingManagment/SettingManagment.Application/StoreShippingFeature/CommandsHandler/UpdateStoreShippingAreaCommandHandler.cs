using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class UpdateStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateStoreShippingAreaCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateStoreShippingAreaCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateStoreShippingAreaCommand, bool>
                        (validator: new Validation.UpdateStoreShippingAreaValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.StoreShippingAreaTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaRepository.UpdateAsync(entity);


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
