using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class GetAllStoreInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetAllStoreInActiveCommand, FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllStoreInActiveCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>>> Handle(Commands.GetAllStoreInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreInActiveTbl>>();

            try
            {


                // **************************************************

                var inActive = await UnitOfWork.StoreInActiveQueryRepository.GetByStoreId(request.StoreId);


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

                    result.WithValue(inActive.ToList());
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
