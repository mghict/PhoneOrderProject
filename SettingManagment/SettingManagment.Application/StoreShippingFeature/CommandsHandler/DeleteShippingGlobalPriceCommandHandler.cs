using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class DeleteShippingGlobalPriceCommandHandler :
        MediatR.IRequestHandler<Commands.DeleteShippingGlobalPriceCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteShippingGlobalPriceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteShippingGlobalPriceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result =
                new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteShippingGlobalPriceCommand>
                        (validator: new Validation.DeleteShippingGlobalPriceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var inActive = await UnitOfWork.ShippingGlobalPriceRepository.DeleteByIdAsync(request.Id);


                // **************************************************

                // **************************************************

                if (inActive != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

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
