using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class GetAllStoreShippingAreaCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllStoreShippingAreaCommand, FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllStoreShippingAreaCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreShippingAreaTbl>>> Handle(GetAllStoreShippingAreaCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingAreaTbl>>();

            try
            {
                

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingAreaQueryRepository.GetAllAsync();


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
