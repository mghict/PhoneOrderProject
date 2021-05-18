using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class DeleteStoreInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeleteStoreInActiveCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteStoreInActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result> Handle(Commands.DeleteStoreInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteStoreInActiveCommand>
                        (validator: new Validators.DeleteStoreInActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.StoreInActiveRepository.DeleteByIdAsync(request.Id);


                // **************************************************

                // **************************************************

                if (inActive)
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
