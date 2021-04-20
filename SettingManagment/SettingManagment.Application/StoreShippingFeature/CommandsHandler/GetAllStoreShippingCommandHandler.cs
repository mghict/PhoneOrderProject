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
    public class GetAllStoreShippingCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllStoreShippingCommand, FluentResults.Result<List<Domain.Entities.StoreShippingTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllStoreShippingCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.StoreShippingTbl>>> Handle(GetAllStoreShippingCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.StoreShippingTbl>> result =
                new FluentResults.Result<List<Domain.Entities.StoreShippingTbl>>();

            try
            {


                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingQueryRepository.GetAllAsync();


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
