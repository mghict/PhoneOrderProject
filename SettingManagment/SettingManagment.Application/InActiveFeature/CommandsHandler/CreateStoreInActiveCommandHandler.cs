using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class CreateStoreInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateStoreInActiveCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateStoreInActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result> Handle(Commands.CreateStoreInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateStoreInActiveCommand>
                        (validator: new Validators.CreateStoreInActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.StoreInActiveTbl>(request);

                var inActive = await UnitOfWork.StoreInActiveRepository.InsertAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive != null)
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
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
