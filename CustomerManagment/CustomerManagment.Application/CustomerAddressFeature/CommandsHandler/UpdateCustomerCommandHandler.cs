using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
    public class UpdateCustomerAddressCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdateCustomerAddressCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public UpdateCustomerAddressCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }


        public async Task<Result> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateCustomerAddressCommand, long>
                        (validator: new Validators.UpdateCustomerAddressValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerAddressTbl>(request);
                
                var operationResult = await UnitOfWork.CustomerAddressRepository.UpdateAsync(entity);

                if (operationResult)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                }
                else
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.ErrorDone);
                }

                // **************************************************

                // **************************************************


                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
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