using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class DeleteStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteStoreShippingAreaCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteStoreShippingAreaCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteStoreShippingAreaCommand, bool>
                        (validator: new Validation.DeleteStoreShippingAreaValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingAreaTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaRepository.DeleteByIdAsync(request.Id);


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
