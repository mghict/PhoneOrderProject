using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
   public  class GetCustomerAddressesCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetCustomerAddressesCommand, FluentResults.Result<List<BehsamFramework.Models.CustomerAddressModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetCustomerAddressesCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<BehsamFramework.Models.CustomerAddressModel>>> Handle(GetCustomerAddressesCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<BehsamFramework.Models.CustomerAddressModel>> result = 
                new FluentResults.Result<List<BehsamFramework.Models.CustomerAddressModel>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetCustomerAddressesCommand, List<BehsamFramework.Models.CustomerAddressModel>>
                        (validator: new Validators.GetCustomerAddressesValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var cust = await UnitOfWork.CustomerAddressRepository.GetCustomerAddressAsync(request.Id);

                var res = Mapper.Map<List<BehsamFramework.Models.CustomerAddressModel>>(cust);
                // **************************************************

                // **************************************************

                if (res != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(res.ToList());
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