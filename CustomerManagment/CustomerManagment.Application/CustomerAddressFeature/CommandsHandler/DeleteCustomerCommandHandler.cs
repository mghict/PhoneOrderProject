using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
   public  class DeleteCustomerAddressCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeleteCustomerAddressCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteCustomerAddressCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteCustomerAddressCommand, long>
                        (validator: new Validators.DeleteCustomerAddressValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var cust = await UnitOfWork.CustomerAddressRepository.DeleteByIdAsync(request.Id);
                

                // **************************************************

                // **************************************************

                if(cust)
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                else
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.ErrorDone);
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