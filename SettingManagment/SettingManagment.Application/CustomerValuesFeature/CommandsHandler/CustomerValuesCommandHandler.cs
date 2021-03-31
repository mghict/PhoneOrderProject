using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using SettingManagment.Domain.Entities;
using SettingManagment.Persistence;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class CustomerValuesCommandHandler:
        Object,
        MediatR.IRequestHandler
        <Commands.CustomerValuesCommand, FluentResults.Result<Domain.Entities.CustomerAttribute>>
    {

        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public CustomerValuesCommandHandler(IQueryUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<CustomerAttribute>> Handle(CustomerValuesCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<CustomerAttribute> result = new FluentResults.Result<CustomerAttribute>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CustomerValuesCommand, CustomerAttribute>
                        (validator: new Validators.CustomerValuesValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                

                var values = await UnitOfWork.CustomerValuesQueryRepository.GetCustomerAttributeByIdAsync(request.Id);
                if (values == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.UserNamePassNotFound);
                }

                result.WithValue(values);
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
