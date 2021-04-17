using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class DeleteAreaInfoCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteAreaInfoCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteAreaInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<bool>> Handle(DeleteAreaInfoCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<bool> result =
                new FluentResults.Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteAreaInfoCommand, bool>
                        (validator: new Validators.DleteAreaInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.AreaInfoRepository.DeleteByIdAsync(request.Id);


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
