using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class GetByIdAreaInfoCommandHandler :
        MediatR.IRequestHandler<Commands.GetByIdAreaInfoCommand, FluentResults.Result<Domain.Entities.AreaInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdAreaInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<Domain.Entities.AreaInfoTbl>> Handle(GetByIdAreaInfoCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.AreaInfoTbl> result =
                new FluentResults.Result<Domain.Entities.AreaInfoTbl>();

            try
            {


                // **************************************************

                var inActive = await UnitOfWork.AreaInfoQueryRepository.GetByIdAsync(request.Id);


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
