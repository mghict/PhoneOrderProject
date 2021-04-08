using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.TimeSheetFeature.CommandsHandler
{
    public class GetAllTimeSheetCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetAllTimeSheetCommand, FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public GetAllTimeSheetCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>> Handle(Commands.GetAllTimeSheetCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>> result = 
                new FluentResults.Result<List<Domain.Entities.StoreTimeSheetTbl>>();

            try
            {
                

                // **************************************************

                var exists = await QueryUnitOfWork.TimeSheetQueryRepository.GetAllAsync();
                

                if (exists!=null)
                {
                    result.WithValue(exists.ToList());
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
