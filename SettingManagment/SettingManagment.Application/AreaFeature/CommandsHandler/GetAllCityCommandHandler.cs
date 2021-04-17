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
    public class GetAllCityCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllCityCommand, FluentResults.Result<List<Domain.Entities.CityTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllCityCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.CityTbl>>> Handle(GetAllCityCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.CityTbl>> result =
                new FluentResults.Result<List<Domain.Entities.CityTbl>>();

            try
            {


                // **************************************************

                var lst = await UnitOfWork.CityQueryRepository.GetAllAsync();

                // **************************************************

                // **************************************************

                if (lst != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(lst.ToList());
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
