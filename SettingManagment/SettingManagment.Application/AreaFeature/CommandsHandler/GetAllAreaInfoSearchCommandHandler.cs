using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class GetAllAreaInfoSearchCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllAreaInfoSearchCommand, FluentResults.Result<Domain.Entities.AreaModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllAreaInfoSearchCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<Domain.Entities.AreaModel>> Handle(GetAllAreaInfoSearchCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<Domain.Entities.AreaModel> result =
                new FluentResults.Result<Domain.Entities.AreaModel>();

            try
            {


                // **************************************************

                var lst = await UnitOfWork.AreaInfoQueryRepository.GetAllSearch(request.SearchKey,request.PageNumber,request.PageSize);


                // **************************************************

                // **************************************************

                if (lst != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(lst);
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
