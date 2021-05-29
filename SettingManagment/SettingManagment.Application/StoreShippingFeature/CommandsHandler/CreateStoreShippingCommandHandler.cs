using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{


    public class CreateStoreShippingCommandHandler :
        MediatR.IRequestHandler<Commands.CreateStoreShippingCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateStoreShippingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateStoreShippingCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<int> result =
                new FluentResults.Result<int>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateStoreShippingCommand,int>
                        (validator: new Validation.CreateStoreShoppingValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.StoreShippingTbl>(request);

                var inActive = await UnitOfWork.StoreShippingRepository.InsertAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive !=null)
                {
                    result.WithSuccess
                       (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(inActive.Id);
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

            return result;
        }
    }
}
