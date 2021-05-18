using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class GetByIdStoreInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdStoreInActiveCommand, FluentResults.Result<Domain.Entities.StoreInActiveTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdStoreInActiveCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<Domain.Entities.StoreInActiveTbl>> Handle(Commands.GetByIdStoreInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.StoreInActiveTbl> result =
                new FluentResults.Result<Domain.Entities.StoreInActiveTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdStoreInActiveCommand, Domain.Entities.StoreInActiveTbl>
                        (validator: new Validators.GetByIdStoreInActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.StoreInActiveQueryRepository.GetByIdAsync(request.Id);


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
