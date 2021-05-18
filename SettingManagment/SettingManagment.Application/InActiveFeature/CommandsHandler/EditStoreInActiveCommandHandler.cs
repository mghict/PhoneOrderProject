using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class EditStoreInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.EditStoreInActiveCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public EditStoreInActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result> Handle(Commands.EditStoreInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.EditStoreInActiveCommand>
                        (validator: new Validators.EditStoreInActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var entity = Mapper.Map<Domain.Entities.StoreInActiveTbl>(request);

                var isSuccess = await UnitOfWork.StoreInActiveRepository.UpdateAsync(entity);


                // **************************************************

                // **************************************************

                if (isSuccess)
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
