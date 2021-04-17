using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class GetAreaTypeAreaInfoCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllAreaTypeCommand, FluentResults.Result<List<Domain.Entities.AttributeStatus>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAreaTypeAreaInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.AttributeStatus>>> Handle(GetAllAreaTypeCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.AttributeStatus>> result =
                new FluentResults.Result<List<Domain.Entities.AttributeStatus>>();

            try
            {


                // **************************************************

                var inActive = await UnitOfWork.AreaInfoQueryRepository.GetAreaType();


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
