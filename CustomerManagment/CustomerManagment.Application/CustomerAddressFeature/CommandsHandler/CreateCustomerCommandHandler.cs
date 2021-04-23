using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
    public class CreateCustomerAddressCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateCustomerAddressCommand,FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public CreateCustomerAddressCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<long>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<long> result = new FluentResults.Result<long>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateCustomerAddressCommand, long>
                        (validator: new Validators.CreateCustomerAddressValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerAddressTbl>(request);

                var address = await UnitOfWork.CustomerAddressRepository.InsertAsync(entity);
                if (address == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                result.WithValue(address.Id);
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
