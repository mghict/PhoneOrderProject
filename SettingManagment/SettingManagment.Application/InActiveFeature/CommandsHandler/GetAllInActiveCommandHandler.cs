using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.InActiveFeature.CommandsHandler
{
    public class GetAllInActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetAllInActiveCommand, FluentResults.Result<List<Domain.Entities.InActiveTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllInActiveCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.InActiveTbl>>> Handle(Commands.GetAllInActiveCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.InActiveTbl>> result =
                new FluentResults.Result<List<Domain.Entities.InActiveTbl>>();

            try
            {
                

                // **************************************************

                var inActive = await UnitOfWork.InActiveQueryRepository.GetAllAsync();


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
