using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
   public  class GetByIdCustomerAddressCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdCustomerAddressCommand, FluentResults.Result<BehsamFramework.Models.CustomerAddressModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdCustomerAddressCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<BehsamFramework.Models.CustomerAddressModel>> Handle(GetByIdCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerAddressModel> result = 
                new FluentResults.Result<BehsamFramework.Models.CustomerAddressModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdCustomerAddressCommand, BehsamFramework.Models.CustomerAddressModel>
                        (validator: new Validators.GetByIdCustomerAddressValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var cust = await UnitOfWork.CustomerAddressRepository.GetByIdAsync(request.Id);


                // **************************************************

                // **************************************************

                if (cust != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(Mapper.Map<BehsamFramework.Models.CustomerAddressModel>(cust));
                }
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