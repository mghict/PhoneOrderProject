using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class GetByIdInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdInActiveCommand, FluentResults.Result<Domain.Entities.InActiveTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdInActiveCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<Domain.Entities.InActiveTbl>> Handle(Commands.GetByIdInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.InActiveTbl> result = 
                new FluentResults.Result<Domain.Entities.InActiveTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdInActiveCommand, Domain.Entities.InActiveTbl>
                        (validator: new Validators.GetByIdInActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.InActiveQueryRepository.GetByIdAsync(request.Id);


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
