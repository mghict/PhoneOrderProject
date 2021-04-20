using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class CreateStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.CreateStoreShippingAreaCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateStoreShippingAreaCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<int> result =
                new FluentResults.Result<int>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateStoreShippingAreaCommand, int>
                        (validator: new Validation.CreateStoreShoppingAreaValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.StoreShippingAreaTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaRepository.InsertAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(inActive.Id);

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
